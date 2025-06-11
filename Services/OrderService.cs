using eBazzar.DBcontext;
using eBazzar.DTO;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.EntityFrameworkCore;

public interface IOrderService
{
    Task<Orders> CreateOrder(CreateOrderRequest request);
    Task<Orders> GetOrderById(int orderId);
    Task<Orders> GetOrderByRazorpayId(string razorpayOrderId);
    //Task UpdateOrderStatus(int orderId, string status);
    Task UpdateRazorpayOrderId(int orderId, string razorpayOrderId);
    Task UpdatePaymentDetails(PaymentSuccessRequest request);
}

// Services/OrderService.cs
public class OrderService : IOrderService
{
    private readonly AppDBContext _context;
    private readonly IProduct _productService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(AppDBContext context, IProduct productService, ILogger<OrderService> logger)
    {
        _context = context;
        _productService = productService;
        _logger = logger;
    }

    // Naya order create karne ka method
    public async Task<Orders> CreateOrder(CreateOrderRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // 1. Pehle order create karo
            var order = new Orders
            {
                user_id = request.UserId,
                total_price = request.TotalAmount,
                status = "Pending",
                createdAt = DateTime.Now,
                //currency = request.Currency ?? "INR"
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            // 2. Order items add karo
            foreach (var item in request.Items)
            {
                var product = await _productService.getProductById((int) item.product_id);

                if (product == null)
                {
                    throw new Exception($"Product {(int)item.product_id} not available");
                }

                var orderDetail = new OrderDetails
                {
                    order_id = order.order_id,
                    product_id = (int)item.product_id,
                    quantity = item.quantity,
                    final_price = item.final_price,
                    createdAt = DateTime.Now
                };

                _context.orderDetails.Add(orderDetail);

                // Product stock update karo
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return order;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Order creation failed");
            throw;
        }
    }

    // Razorpay order ID update karne ka method
    public async Task UpdateRazorpayOrderId(int orderId, string razorpayOrderId)
    {
        var order = await _context.orders.FindAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        order.razorpayOrderId = razorpayOrderId;
        order.status = "PaymentPending";

        await _context.SaveChangesAsync();
    }

    // Payment successful hone par update karne ka method
    public async Task UpdatePaymentDetails(PaymentSuccessRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // 1. Order fetch karo
            var order = await _context.orders
                .FirstOrDefaultAsync(o => o.razorpayOrderId == request.RazorpayOrderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            // 2. Payment record create/update karo
            var payment = await _context.payments
                .FirstOrDefaultAsync(p => p.order_id == order.order_id);

            if (payment == null)
            {
                payment = new Payments
                {
                    order_id = order.order_id,
                    user_id = order.user_id,
                    payment_date = DateTime.Now,
                    //createdAt = DateTime.Now
                };
                _context.payments.Add(payment);
            }

            payment.razorpay_order_id = request.RazorpayOrderId;
            //payment.razorpay_payment_id = request.RazorpayPaymentId;
            //payment.razorpay_signature = request.RazorpaySignature;
            //payment.payment_status = "captured";
            payment.amount = order.total_price ?? 0;

           
            order.status = "Paid";

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Payment update failed");
            throw;
        }
    }

    // Order by ID get karne ka method
    public async Task<Orders> GetOrderById(int orderId)
    {
        return await _context.orders
            .Include(o => o.orderDetails)
            .FirstOrDefaultAsync(o => o.order_id == orderId);
    }

    // Razorpay order ID se order get karne ka method
    public async Task<Orders> GetOrderByRazorpayId(string razorpayOrderId)
    {
        return await _context.orders
            .FirstOrDefaultAsync(o => o.razorpayOrderId == razorpayOrderId);
    }
}