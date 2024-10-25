

using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.system
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        //Crear roless
        Task<bool> CreateRole(string roleName, List<string> permissions);

        //Asigar rol a los usuarios
        Task<bool> AssignRoleToUser(int userId, int roleId);

        //Remueve un rol asignado a un usuario.
        Task<bool> RemoveRoleFromUser(int userId, int roleId);

        //Verifica si un rol existe en el sistema.
        Task<bool> RoleExists(string roleName);

        //Obtiene todos los permisos asociados a un rol específico.
        Task<List<string>> GetPermissionsByRole(int roleId);



    }
}
