
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Interfaces.system;

namespace MedicalAppointment.Persistance.Interfaces.system
{
    public interface IStatusRepository : IBaseRepository<Status>
    {

        //Obtener el Status por categoria
        Task<OperationResult> GetStatusesByCategory(string category);

        //Obtencion por Status
        Task<OperationResult> GetActiveStatuses();


    }
}
