using System.Net;
using System.Net.Mail;

namespace ToDoApp.Handlers
{
    public class SendEmail
    {
        public static void Email(string to, string subject, string body)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mailMessage= new MailMessage();
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.From = new MailAddress(""); // A sender's email address.
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml= true;
            mailMessage.Priority = MailPriority.High;

            //Configuration the smtp client
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("user address email", "MFA"); //Credentials - remember to use MFA with gmail account.
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);
        }
    }
}
