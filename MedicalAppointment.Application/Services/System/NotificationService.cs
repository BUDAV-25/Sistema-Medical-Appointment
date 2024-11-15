

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Response.system.Notification;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.System
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationsRepository _notificationsRepository;
        private ILogger <NotificationService> _logger;

        public NotificationService(INotificationsRepository notificationsRepository, ILogger<NotificationService> logger)
        {
            if (notificationsRepository is null)
            {
                throw new ArgumentNullException(nameof(notificationsRepository));
            }

            _notificationsRepository = notificationsRepository;
            _logger = logger;
        }

        public async Task<NotificationResponse> GetAll()
        {
            NotificationResponse notificationResponse = new NotificationResponse();

            try
            {
                var result = await _notificationsRepository.GetAll();

                if (!result.Success)
                {
                    notificationResponse.IsSuccess = result.Success;
                    notificationResponse.Messages = result.Message;

                    return notificationResponse;
                }
                notificationResponse.Data = result.Data;


            }
            catch (Exception ex)
            {
                notificationResponse.IsSuccess = false;
                notificationResponse.Messages = "Error obteniendo las notificaciones";
                _logger.LogError(notificationResponse.Messages, ex.ToString());
            }
            return notificationResponse;
        }

        public async Task<NotificationResponse> GetById(int id)
        {
            NotificationResponse notificationResponse = new NotificationResponse();

            try
            {
                var result = await _notificationsRepository.GetEntityBy(id);

                if (!result.Success)
                {
                    notificationResponse.IsSuccess = result.Success;
                    notificationResponse.Messages = result.Message;

                    return notificationResponse;
                }

                notificationResponse.Data = result.Data;

            }
            catch (Exception ex)
            {
                notificationResponse.IsSuccess = false;
                notificationResponse.Messages = "Error obteniendo la notificacion by ID";
                _logger.LogError(notificationResponse.Messages, ex.ToString());
            }
            return notificationResponse;
        }

        public async Task<NotificationResponse> SaveAsync(NotificationSaveDto dto)
        {
            NotificationResponse notificationResponse = new NotificationResponse();

            try
            {
                Notifications notifications = new Notifications();
                notifications.UserID = dto.UserID;
                notifications.Message = dto.Message;
                notifications.SentAt = dto.SentAt;

                var result = await _notificationsRepository.Save(notifications);
            }
            catch (Exception ex)
            {
                notificationResponse.IsSuccess = false;
                notificationResponse.Messages = "Error guardando la notificacion";
                _logger.LogError (notificationResponse.Messages, ex.ToString());
            }
            return notificationResponse;
        }

        public async Task<NotificationResponse> UpdateAsync(NotificationUpdateDto dto)
        {
            NotificationResponse notificationResponse = new NotificationResponse();

            try
            {
                var resultGetById = await _notificationsRepository.GetEntityBy(dto.NotificationID);

                if (!resultGetById.Success)
                {
                    notificationResponse.IsSuccess = resultGetById.Success;
                    notificationResponse.Messages = resultGetById.Message;

                    return notificationResponse;
                }

                Notifications notifications = new();

                notifications.NotificationID = dto.NotificationID;
                notifications.UserID = dto.UserID;
                notifications.Message = dto.Message;
                notifications.SentAt = dto.SentAt;

                var result = await _notificationsRepository.Update(notifications);


            }
            catch (Exception ex)
            {
                notificationResponse.IsSuccess = false;
                notificationResponse.Messages = "Error actualizando la notificacion";
                _logger.LogError(notificationResponse.Messages, ex.ToString());
            }
            return notificationResponse;
        }
           
    }
}
