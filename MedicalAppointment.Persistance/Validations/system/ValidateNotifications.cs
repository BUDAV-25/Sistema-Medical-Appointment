

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Validations.system
{
    public class ValidateNotifications
    {
        public OperationResult ValidationSaveNotifications (Notifications notifications, OperationResult result) 
        {
            if (notifications == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (notifications.UserID <= 0)
            {
                result.Success = false;
                result.Message = "El UserID es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(notifications.Message))
            {
                result.Success = false;
                result.Message = "Se requiere un mensaje";
                return result;
            }
            if (notifications.SentAt == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha";
                return result;
            }

            return result;
        }

        public OperationResult ValidationUpdateNotifications(Notifications notifications, OperationResult result) 
        {
            if (notifications == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (notifications.NotificationID <= 0)
            {
                result.Success = false;
                result.Message = "El NotificationID es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(notifications.Message))
            {
                result.Success = false;
                result.Message = "Se requiere un mensaje";
                return result;
            }
            if (notifications.SentAt == null)
            {
                result.Success = false;
                result.Message = "La fecha es requerida";
                return result;
            }

            return result;
        }
    }
}
