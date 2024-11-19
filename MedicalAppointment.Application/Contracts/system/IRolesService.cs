

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Response.system.Roles;

namespace MedicalAppointment.Application.Contracts.system
{
    public interface IRolesService : IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>
    {
    }
}
