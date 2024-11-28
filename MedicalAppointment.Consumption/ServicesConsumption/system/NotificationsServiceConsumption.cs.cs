using MedicalAppointment.Consumption.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ContractsConsumption.system;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class NotificationsServiceConsumption : INotificationsContracts
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<NotificationsServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public NotificationsServiceConsumption(IBaseConsumption baseConsumption, ILogger<NotificationsServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<NotificationsGetAllModel> GetAll()
        {
            NotificationsGetAllModel notificationsGetAll = new NotificationsGetAllModel();

            try
            {
                notificationsGetAll = await _baseConsumption.GetAllConsumption<NotificationsGetAllModel>("Notifications/GetAllNotifications");
            }
            catch (Exception ex)
            {
                notificationsGetAll.isOkay = false;
                notificationsGetAll.mensaje = "Error al obtener las notificaciones.";
                _logger.LogError($"{notificationsGetAll.mensaje}{ex.ToString()}");
            }
            return notificationsGetAll;
        }

        public async Task<NotificationsGetByIdModel> GetById(int id)
        {
            NotificationsGetByIdModel notificationsGetById = new NotificationsGetByIdModel();

            try
            {
                notificationsGetById = await _baseConsumption.GetByIdConsumption<NotificationsGetByIdModel>($"Notifications/GetNotificationsBy{id}");
            }
            catch (Exception ex)
            {
                notificationsGetById.isOkay = false;
                notificationsGetById.mensaje = "Error al obtener esta notificacion.";
                _logger.LogError($"{notificationsGetById.mensaje} {ex.ToString()}");
            }
            return notificationsGetById;
        }

        public async Task<NotificationSaveDto> Save(NotificationSaveDto saveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                saveDto.SentAt = DateTime.Now;
                var notificationSave = await _baseConsumption.SaveConsumption<NotificationSaveDto>("Notifications/SaveNotifications", saveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al guardar la notificacion.";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString}");
            }
            return saveDto;
        }

        public async Task<NotificationUpdateDto> Update(NotificationUpdateDto updateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                updateDto.SentAt = DateTime.Now;
                var notificationUpdate = await _baseConsumption.UpdateConsumption<NotificationUpdateDto>($"Notifications/UpdateNotifications{updateDto.NotificationID}", updateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al actualizar la notificacion.";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return updateDto;
        }
    }
}
