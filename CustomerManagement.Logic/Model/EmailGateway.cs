using CSharpFunctionalExtensions;
using System.Net.Mail;

namespace CustomerManagement.Logic.Model
{
    public class EmailGateway : IEmailGateway
    {
        public Result  SendPromotionNotification(string email, CustomerStatus newStatus)
        {
            return SendEmail(email, "Congratulations!", "You've been promoted to " + newStatus);
        }

        private Result SendEmail(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage("noreply@northwind.com", to, subject, body);
                var client = new SmtpClient();
                client.Send(message);
                return Result.Ok();
            }
            catch (SmtpException)
            {
                return Result.Fail("Email not sent");
            }        
        }
    }
}
