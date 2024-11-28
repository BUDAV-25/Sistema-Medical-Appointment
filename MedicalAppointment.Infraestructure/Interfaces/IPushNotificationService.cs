using MedicalAppointment.Infraestructure.Models;
using MedicalAppointment.Infraestructure.Nucleo;

namespace MedicalAppointment.Infraestructure.Interfaces
{
    public interface IPushNotificationService
    {
        Task <NotificationResult> SendPushNotification(PushModel pushNotification);

    }
}
