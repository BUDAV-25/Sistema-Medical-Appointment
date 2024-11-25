using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;
using MedicalAppointment.Consumption.IClientService.system;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MedicalAppointment.Consumption.ModelsMethods.Core;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class NotificationsServiceConsumption : INotificationsClientService
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<NotificationsServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public NotificationsServiceConsumption(IBaseConsumption baseConsumption, ILogger<NotificationsServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }
        public async Task<NotificationsGetAllModel> GetNotifications()
        {
            NotificationsGetAllModel notificationsGetAll = new NotificationsGetAllModel();

            try
            {
                notificationsGetAll = await _baseConsumption.GetAllConsumption<NotificationsGetAllModel>("Notifications/GetAllNotifications");
            }
            catch (Exception ex)
            {
                notificationsGetAll.isOkay = false;
                notificationsGetAll.mensaje = "Error obteniendo las notificaciones";
                _logger.LogError($"{notificationsGetAll.mensaje} {ex.ToString()}");
            }
            return notificationsGetAll;
        }

        public async Task<NotificationsGetByIdModel> GetNotificationsById(int id)
        {
            NotificationsGetByIdModel notificationsGetById = new NotificationsGetByIdModel();

            try
            {
                notificationsGetById = await _baseConsumption.GetByIdConsumption<NotificationsGetByIdModel>($"Notifications/GetNotificationsBy{id}");
            }
            catch (Exception ex)
            {
                notificationsGetById.isOkay = false;
                notificationsGetById.mensaje = "Error obteniendo los detalles.";
                _logger.LogError($"{notificationsGetById.mensaje} {ex.ToString()}");

            }
            return notificationsGetById;
        }

        public async Task<NotificationSaveDto> SaveNotification(NotificationSaveDto notificationSaveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();
            try
            {
                notificationSaveDto.SentAt = DateTime.Now;
                var response = await _baseConsumption.SaveConsumption<NotificationSaveDto>("Notifications/SaveNotifications", notificationSaveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error obteniendo las notificaciones";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return (notificationSaveDto);
        }

        public async Task<NotificationUpdateDto> UpdateNotification(NotificationUpdateDto notificationUpdateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                notificationUpdateDto.SentAt = DateTime.Now;
                var response = await _baseConsumption.UpdateConsumption<NotificationUpdateDto>($"Notifications/UpdateNotifications{notificationUpdateDto.NotificationID}", notificationUpdateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error actualizando la notificacion";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return (notificationUpdateDto);
        }
        
    }
}
