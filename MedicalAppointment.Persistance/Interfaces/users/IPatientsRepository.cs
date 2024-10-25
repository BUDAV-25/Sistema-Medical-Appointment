using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IPatientsRepository : IBaseRepository<Patients>
    {
        public void FindBloodType(char bloodType);
        public void FindInsuranceProvider(int insuranceProviderId);
        public void FindGender(char gender);
    }
}
