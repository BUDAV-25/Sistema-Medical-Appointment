using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;

namespace MedicalAppointment.Consumption.ContractsConsumption.system
{
    public interface INotificationsContracts : Interfaces<NotificationsGetAllModel, NotificationsGetByIdModel, NotificationSaveDto, NotificationUpdateDto>
    {
    }
}
