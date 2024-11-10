

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
        private readonly INotificationService _notificationService;

        public NotificationService(INotificationsRepository notificationsRepository, ILogger<NotificationService> logger, INotificationService notificationService)
        {
            if (notificationsRepository is null)
            {
                throw new ArgumentNullException(nameof(notificationsRepository));
            }

            _notificationsRepository = notificationsRepository;
            _logger = logger;
            _notificationService = notificationService;
        }

        public async Task<NotificationResponse> GetAll()
        {
            NotificationResponse notificationResponse = new NotificationResponse();

            try
            {
                var result = await _notificationsRepository.GetAll();

                List<NotificationGetDto> notifications = ((List<Notifications>)result.Data).Select(notifications => new NotificationGetDto()

                {
                    NotificationID = notifications.NotificationID,
                    UserID = notifications.UserID,
                    Message = notifications.Message,
                    SentAt = (DateTime)notifications.SentAt,

                }).ToList();

                notificationResponse.IsSuccess = result.Success;
                notificationResponse.Model = notifications;

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

                Notifications notifications = (Notifications)result.Data;
                NotificationGetDto notificationGetDto = new NotificationGetDto()
                {
                    NotificationID = notifications.NotificationID,
                    UserID = notifications.UserID,
                    Message = notifications.Message,
                    SentAt = (DateTime)notifications.SentAt
                };
                notificationResponse.IsSuccess = result.Success;
                notificationResponse.Model = notificationGetDto;

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
                notifications.NotificationID = dto.NotificationID;
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
                var result = await _notificationsRepository.GetEntityBy(dto.NotificationID);


                Notifications notifications = (Notifications)result.Data;
                NotificationGetDto notificationGetDto = new NotificationGetDto()
                {
                    Message = notifications.Message,
                    SentAt = (DateTime)notifications.SentAt
                };
                notificationResponse.IsSuccess = result.Success;
                notificationResponse.Model = notificationGetDto;

            }
            catch (Exception ex)
            {
                notificationResponse.IsSuccess = false;
                notificationResponse.Messages = "Error obteniendo la notificacion by ID";
                _logger.LogError(notificationResponse.Messages, ex.ToString());
            }
            return notificationResponse;
        }
           
    }
}
