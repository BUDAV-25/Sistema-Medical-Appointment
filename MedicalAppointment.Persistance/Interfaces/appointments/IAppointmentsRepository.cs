

using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.appointments
{
    public interface IAppointments : IBaseRepository <Appointments>
    {
        //Metodo para confirmar o rechazar la cita
        Task<bool> ConfirmOrRejectAppointment(int appointmentId, bool isConfirmed, string? reason);

    }
}
