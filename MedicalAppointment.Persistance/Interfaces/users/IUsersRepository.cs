using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        Task<OperationResult> FindUserRole(int roleId);
    }
}
