

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.system
{
    public sealed class NotificationsRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<NotificationsRepository> logger) : BaseRepository<Notifications>(medicalAppointmentContext), INotificationsRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<NotificationsRepository> logger = logger;

        public async override Task<OperationResult> Save(Notifications entity)
        {

            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (entity.UserID <= 0)
            {
                result.Success = false;
                result.Message = "El UserID es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Message))
            {
                result.Success = false;
                result.Message = "Se requiere un mensaje";
                return result;
            }
            if (entity.SentAt == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha";
                return result;
            }
            if (await base.Exists(notifications => notifications.NotificationID == entity.NotificationID
            && notifications.UserID == entity.UserID))
            {

                result.Success = false;
                result.Message = "Esta notificacion ya existe";
                return result;
            }
            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al crear la notificacion";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

        public async override Task<OperationResult> Update(Notifications entity)
        {

            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (entity.NotificationID <= 0)
            {
                result.Success = false;
                result.Message = "El NotificationID es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Message))
            {
                result.Success = false;
                result.Message = "Se requiere un mensaje";
                return result;
            }
            if (entity.SentAt == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }
            try
            {
                Notifications? notificationsToUpdate = await medical_AppointmentContext.Notifications.FindAsync(entity.NotificationID);

                notificationsToUpdate.NotificationID = entity.NotificationID;
                notificationsToUpdate.Message = entity.Message;
                notificationsToUpdate.SentAt = entity.SentAt;

                result = await base.Update(notificationsToUpdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la notificacion";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        /*
        public async override Task<OperationResult> Remove(Notifications entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }

            if (entity.NotificationID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el NotificationID";
                return result;
            }

            try
            {
                Notifications? notificationsToRemove = await medical_AppointmentContext.Notifications.FindAsync(entity.NotificationID);

                notificationsToRemove.NotificationID = entity.NotificationID;
                notificationsToRemove.Message = entity.Message;
                notificationsToRemove.SentAt = entity.SentAt;

                await base.Update(notificationsToRemove);

            }
            catch (Exception ex)
            { 
                result.Success = false;
                result.Message = "Error al remover la notificacion";
                logger.LogError(result.Message, ex.ToString());  
            }

            return result;
        
            }
        */

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from system in medical_AppointmentContext.Notifications
                                     join user in medical_AppointmentContext.User on system.UserID equals user.UserID
                                     orderby system.NotificationID descending

                                     select new NotificationsModel()
                                     {
                                         NotificationID = system.NotificationID,
                                         UserID = user.UserID,
                                         Message = system.Message,
                                         SentAt = system.SentAt

                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }


        public async override Task<OperationResult> GetEntityBy(int ID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from system in medical_AppointmentContext.Notifications
                                     join user in medical_AppointmentContext.User on system.UserID equals user.UserID
                                     where system.NotificationID == ID

                                     select new NotificationsModel()
                                     {
                                         NotificationID = system.NotificationID,
                                         UserID = user.UserID,
                                         Message = system.Message,
                                         SentAt = system.SentAt

                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }


        public Task<OperationResult> GetNotificationsByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> ScheduleCustomReminder(int patientId, int appointmentId, int? templateId, string? customMessage, DateTime sendDateTime)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> SendNotification(int userId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
