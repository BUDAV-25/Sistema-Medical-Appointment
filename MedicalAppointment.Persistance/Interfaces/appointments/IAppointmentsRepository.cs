

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IAppointmentsRepository : IBaseRepository <Appointments>
    {
        //Metodo para confirmar o rechazar la cita
        Task<OperationResult> ConfirmOrRejectAppointment(int appointmentId, bool isConfirmed, string? reason);

    }
}

// Agregar metodos para traer los las citas de los pacientes y disponivididad del doctor en ciertas fechas seleccionadas