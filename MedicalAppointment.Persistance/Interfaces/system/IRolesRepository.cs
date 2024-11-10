

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Interfaces.system;

namespace MedicalAppointment.Persistance.Interfaces.system
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        //Crear roless
        Task<OperationResult> CreateRole(string roleName, List<string> permissions);

        //Asigar rol a los usuarios
        Task<OperationResult> AssignRoleToUser(int userId, int roleId);

        //Remueve un rol asignado a un usuario.
        Task<OperationResult> RemoveRoleFromUser(int userId, int roleId);

        //Verifica si un rol existe en el sistema.
        Task<OperationResult> RoleExists(string roleName);

        //Obtiene todos los permisos asociados a un rol específico.
        Task<List<string>> GetPermissionsByRole(int roleId);



    }
}
