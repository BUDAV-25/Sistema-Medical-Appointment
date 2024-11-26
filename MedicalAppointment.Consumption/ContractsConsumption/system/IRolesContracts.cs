using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;

namespace MedicalAppointment.Consumption.ContractsConsumption.system
{
    public interface IRolesContracts : Interfaces<RolesGetAllModel, RolesGetByIdModel, RolesSaveDto, RolesUpdateDto>
    {
    }
}
