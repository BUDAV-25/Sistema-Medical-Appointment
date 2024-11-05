using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        Task<OperationResult> FindUserRole(int roleId);
    }
}
