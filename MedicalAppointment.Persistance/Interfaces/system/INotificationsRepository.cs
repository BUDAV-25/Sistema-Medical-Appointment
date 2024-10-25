
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.system
{
    public interface INotificationsRepository : IBaseRepository<Notifications>
    {
        //Mandar notificación
        Task<bool> SendNotification(int userId, string message);

        //Este método permite a los médicos enviar recordatorios personalizados, usando plantillas predefinidas o mensajes específicos para cada paciente
        Task<bool> ScheduleCustomReminder(int patientId, int appointmentId, int? templateId, string? customMessage, DateTime sendDateTime);


    }
}
