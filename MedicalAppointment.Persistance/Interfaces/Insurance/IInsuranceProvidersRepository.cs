
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.Insurance
{
    public interface IInsuranceProvidersRepository : IBaseRepository <InsuranceProviders>
    {
        Task<OperationResult>GetByCountry(string Country);
        Task<OperationResult> GetByIsPreferred(string isPreferred);
    }
}

