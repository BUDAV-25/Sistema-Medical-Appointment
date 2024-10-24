

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IAppointments : IBaseRepository <Appointments>
    {
        //Descripción: Verifica el estado de una cita (pendiente, confirmada, cancelada, completada).
        string CheckAppointmentStatus(int appointmentId);

        //Envía un recordatorio al paciente sobre su cita a través de email o SMS.
        void SendAppointmentReminder(int appointmentId);

        //Consulta los espacios disponibles para hacer una nueva cita según la disponibilidad del médico.
        List<DateTime> GetAvailableSlots(int doctorId, DateTime date);

        //Genera un reporte de todas las citas de un paciente o un médico en un período de tiempo.
        string GenerateAppointmentReport(int userId, DateTime startDate, DateTime endDate);

        //Marca una cita como "no show" si el paciente no asistió.
        void MarkAsNoShow(int appointmentId);


    }
}
