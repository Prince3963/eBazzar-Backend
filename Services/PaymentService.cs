using eBazzar.DBcontext;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PaymentService : IPaymentService
{
    private readonly RazorpayClient _razorpayClient;
    private readonly IPaymentRepo paymentRepo;
    private readonly IUserRepo userRepo;
    private readonly AppDBContext dbContext;

    public PaymentService(IOptions<RazorpaySettings> razorpaySettings, IPaymentRepo paymentRepo, IUserRepo userRepo, AppDBContext dbContext)
    {
        this._razorpayClient = new RazorpayClient(razorpaySettings.Value.Key, razorpaySettings.Value.Secret);
        this.paymentRepo = paymentRepo;
        this.userRepo = userRepo;
        this.dbContext = dbContext;
    }

    public async Task<ServiceResponse<string>> CreateOrderAsync(PaymentRequest request, int userId)
    {
        var response = new ServiceResponse<string>();

        try
        {
            var existUser = await userRepo.getUserById(userId);

            if (existUser == null)
            {
                response.data = null;
                response.message = "User not found";
                response.status = false;
                return response;
            }

            var options = new Dictionary<string, object>
        {
            { "amount", Convert.ToInt32(request.amount * 100) },
            { "currency", "INR" },
            { "receipt", request.razorpayOrderId }
        };

            Razorpay.Api.Order razorpayOrder = _razorpayClient.Order.Create(options);

            var payment = new Payments
            {
                razorpay_order_id = razorpayOrder["id"].ToString(),
                amount = request.amount,
                payment_date = DateTime.Now,
                user_id = existUser.user_id,
            };

            await paymentRepo.addPayment(payment);

            response.data = razorpayOrder["id"].ToString();
            response.message = "Payment successful.";
            response.status = true;

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Razorpay error: {ex.Message}");
            response.data = null;
            response.message = "Payment failed due to an internal error.";
            response.status = false;
            return response;
        }
    }

    public async Task<bool> VerifyPayment(PaymentVerificationRequest request, int userId)
    {
        var attributes = new Dictionary<string, string>
    {
        { "razorpay_order_id", request.RazorpayOrderId },
        { "razorpay_payment_id", request.RazorpayPaymentId },
        { "razorpay_signature", request.RazorpaySignature }
    };

        try
        {
            Utils.verifyPaymentSignature(attributes);

            // Step 1: Update Payments Table
            var payment = await dbContext.payments
                .FirstOrDefaultAsync(p => p.razorpay_order_id == request.RazorpayOrderId);

            if (payment == null) return false;

            payment.razorpay_payment_id = request.RazorpayPaymentId;
            payment.razorpay_signature = request.RazorpaySignature;

            dbContext.payments.Update(payment);
            await dbContext.SaveChangesAsync();

            // Step 2: Create Order
            var order = new Orders
            {
                user_id = userId,
                address_id = request.AddressId,
                payment_id = payment.payment_id,
                status = "Placed",
                total_price = request.CartItems.Sum(i => i.ProductPrice * i.Quantity),
                razorpay_order_id = request.RazorpayOrderId
            };

            await dbContext.orders.AddAsync(order);
            await dbContext.SaveChangesAsync(); // to get order_id

            // Step 3: Add OrderDetails
            foreach (var item in request.CartItems)
            {
                var orderDetail = new OrderDetails
                {
                    order_id = order.order_id,
                    productId = item.ProductId,
                    productName = item.ProductName,
                    productPrice = item.ProductPrice,
                    quantity = item.Quantity,
                    productImage = item.ProductImage
                };

                await dbContext.orderDetails.AddAsync(orderDetail);
            }

            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Verification failed: " + ex.Message);
            return false;
        }
    }

}