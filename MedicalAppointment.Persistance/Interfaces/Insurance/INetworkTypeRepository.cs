

using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.Insurance
{
    public interface INetworkTypeRepository : IBaseRepository<NetworkType>
    {
        Task<OperationResult> GetBynetworkdescription(string Description);
       
    }

}
