
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;

namespace MedicalAppointment.Consumption.IClientService.system
{
    public interface IRolesClientService
    {
        Task<RolesGetAllModel> GetRoles();
        Task<RolesGetByIdModel> GetRolesById();
        Task<RolesSaveDto> SaveRoles(RolesSaveDto roleSaveDto);
        Task<RolesUpdateDto> UpdateRoles(RolesUpdateDto roleUpdateDto);
    }
}
