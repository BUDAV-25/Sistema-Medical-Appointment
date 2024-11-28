using MedicalAppointment.Infraestructure.Models;
using MedicalAppointment.Infraestructure.Nucleo;

namespace MedicalAppointment.Infraestructure.Interfaces
{
    public interface IEmailService
    {
        Task <NotificationResult> SendEmail(EmailModel email);

    }
}
