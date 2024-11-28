using MedicalAppointment.Infraestructure.Interfaces;
using MedicalAppointment.Infraestructure.Models;
using MedicalAppointment.Infraestructure.Nucleo;
using System.Net;
using System.Net.Mail;

namespace MedicalAppointment.Infraestructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task<NotificationResult> SendEmail(EmailModel email)
        {
            NotificationResult result = new NotificationResult();

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Host = "";
                    client.Port = 0;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("user", "pwd");

                    var message = new MailMessage(email.From!, email.To!);
                    message.Body = email.Subject;
                    message.IsBodyHtml = true;
                    message.Subject = email.Subject;

                    await client.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                result.Messegue = $"Error enviando el Email. {ex.Message}";
            }
            return result;
        }
    }
}
