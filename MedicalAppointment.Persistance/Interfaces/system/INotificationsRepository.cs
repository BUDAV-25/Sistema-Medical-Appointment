
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.system
{
    public interface INotificationsRepository : IBaseRepository<Notifications>
    {
        //Mandar notificación
        Task<OperationResult> SendNotification(int userId, string message);

        //Este método permite a los médicos enviar recordatorios personalizados, usando plantillas predefinidas o mensajes específicos para cada paciente
        Task<OperationResult> ScheduleCustomReminder(int patientId, int appointmentId, int? templateId, string? customMessage, DateTime sendDateTime);

        //Obtener las notificaciones para un rango de fecha
        Task<OperationResult> GetNotificationsByDateRange(DateTime startDate, DateTime endDate);



    }
}
