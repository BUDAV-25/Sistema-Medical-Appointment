

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Response.system.Notification;

namespace MedicalAppointment.Application.Contracts.system
{
    public interface INotificationService : IBaseService<NotificationResponse, NotificationSaveDto, NotificationUpdateDto>
    {
    }
}
