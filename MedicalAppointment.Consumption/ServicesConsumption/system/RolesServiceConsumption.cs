

using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.IClientService.system;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class RolesServiceConsumption : IRolesClientService
    {
        private readonly IBaseConsumption _baseConsumption;
        private ILogger<RolesServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public RolesServiceConsumption(IBaseConsumption baseConsumption, ILogger<RolesServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<RolesGetAllModel> GetRoles()
        {
            RolesGetAllModel rolesGetAll = new RolesGetAllModel();

            try
            {
                rolesGetAll = await _baseConsumption.GetAllConsumption<RolesGetAllModel>("Roles/GetAllRoles");
            }
            catch (Exception ex)
            {
                rolesGetAll.isOkay = false;
                rolesGetAll.mensaje = "Error obteniendo los roles.";
                _logger.LogError($"{rolesGetAll.mensaje} {ex.ToString()}");
            }
            return rolesGetAll;
        }

        public async Task<RolesGetByIdModel> GetRolesById()
        {
            RolesGetByIdModel rolesGetById = new RolesGetByIdModel();

            try
            {
                rolesGetById = await _baseConsumption.GetByIdConsumption<RolesGetByIdModel>("Roles/GetRolesBy");
            }
            catch (Exception ex)
            {
                rolesGetById.isOkay = false;
                rolesGetById.mensaje = "Error obteniendo los detalles.";
                _logger.LogError($"{rolesGetById.mensaje} {ex.ToString()}");

            }
            return rolesGetById;
        }

        public Task<RolesSaveDto> SaveRoles(RolesSaveDto roleSaveDto)
        {
            throw new NotImplementedException();
        }

        public Task<RolesUpdateDto> UpdateRoles(RolesUpdateDto roleUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
