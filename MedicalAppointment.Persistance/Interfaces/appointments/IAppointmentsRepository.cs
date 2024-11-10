

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IAppointmentsRepository : IBaseRepository <Appointment>
    {
        //Metodo para confirmar o rechazar la cita
        Task<OperationResult> ConfirmOrRejectAppointment(int appointmentId, bool isConfirmed, string? reason);

        //Obtener el Appoinment en un rango de fecha dada
        Task<OperationResult> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate);

        //Obtener el Appointment por doctor
        Task<OperationResult> GetAppointmentsByDoctor(int doctorId);

        //Obtener el Appointment por paciente
        Task<OperationResult> GetAppointmentsByPatient(int patientId);
    }
}

// Agregar metodos para traer los las citas de los pacientes y disponivididad del doctor en ciertas fechas seleccionadas