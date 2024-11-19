using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<OperationResult> FindBloodType(char bloodType);
        Task<OperationResult> FindInsuranceProvider(int insuranceProviderId);
        Task<OperationResult> FindGender(char gender);
    }
}
