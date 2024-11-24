

using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;

namespace MedicalAppointment.Consumption.IClientService.system
{
    public interface INotificationsClientService
    {
        Task<NotificationsGetAllModel> GetNotifications();
        Task<NotificationsGetByIdModel> GetNotificationsById();
        Task<NotificationSaveDto> SaveNotification(NotificationSaveDto notificationSaveDto);
    }
}
