using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<OperationResult> getDoctorsByAvailabilityMode(short availabilityModeId);
        Task<OperationResult> FindDoctorSpecialty(short specialtyID);
        Task<OperationResult> FindSpecialityAvailability(short specialtyID, short availabilityModeId);
    }
}
