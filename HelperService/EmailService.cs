using System.Net;
using System.Net.Mail;

public interface IEmailService
{
    Task sendEmail(string to, string subject, string body);
    string createResetPasswordEmailBody(string email, string token);
}

public class EmailService : IEmailService
{
    private readonly string fromEmail = "2024041632@vnsgu.ac.in";
    private readonly string fromPassword = "ogug puwu nlor ryjz";

    public EmailService(IConfiguration configuration)
    {
        
    }


    public async Task sendEmail(string to, string subject, string body)
    {
        try
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };

            var mailMessage = new MailMessage(fromEmail, to, subject, body)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(mailMessage);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error sending email: {e.Message}");
            throw;
        }

    }

    //
    public string createResetPasswordEmailBody(string email, string token)
    {
        string resetLink = $"http://localhost:3000/resetPassword?token={token}";

        string emailBody = $@"
        <h2>Password Reset Request</h2>
        <p>Dear {email},</p>
        <p>We received a request to reset your password. Click the button below to reset your password:</p>
        <a href='{resetLink}' style='background-color: #007bff; color: white; padding: 10px 20px; 
        text-decoration: none; border-radius: 5px;'>Reset Password</a>
        <p>If you didn’t request this, please ignore this email.</p>
        <p><b>Note:</b> This link will expire in 10 minutes.</p>
        <br>
        <p>Best Regards,<br><b>eBazzar</b></p>
    ";

        return emailBody;
    }

}