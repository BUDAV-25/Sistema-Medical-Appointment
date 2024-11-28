using MedicalAppointment.Infraestructure.Nucleo;
using MedicalAppointment.Infraestructure.Models;

namespace MedicalAppointment.Infraestructure.Interfaces
{
    public interface ISmsService
    {
        Task <NotificationResult> SendSms(SmsModel sms);

    }
}
