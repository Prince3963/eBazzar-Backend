using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PaymentService : IPaymentService
{
    private readonly RazorpayClient _razorpayClient;
    private readonly IPaymentRepo paymentRepo;
    private readonly IUserRepo userRepo;

    public PaymentService(IOptions<RazorpaySettings> razorpaySettings, IPaymentRepo paymentRepo, IUserRepo userRepo)
    {
        this._razorpayClient = new RazorpayClient(razorpaySettings.Value.Key, razorpaySettings.Value.Secret);
        this.paymentRepo = paymentRepo;
        this.userRepo = userRepo;
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
                order_id = request.order_id
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

    public bool VerifyPayment(PaymentVerificationRequest request)
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
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}