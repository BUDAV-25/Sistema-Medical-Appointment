using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.system;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class RolesServiceConsumption : IRolesContracts
    {
        private readonly IBaseConsumption _baseConsumption;
        private ILogger<RolesServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public RolesServiceConsumption(IBaseConsumption baseConsumption, ILogger<RolesServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<RolesGetAllModel> GetAll()
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

        public async Task<RolesGetByIdModel> GetById(int id)
        {
            RolesGetByIdModel rolesGetById = new RolesGetByIdModel();

            try
            {
                rolesGetById = await _baseConsumption.GetByIdConsumption<RolesGetByIdModel>($"Roles/GetRolesBy{id}");
            }
            catch (Exception ex)
            {
                rolesGetById.isOkay = false;
                rolesGetById.mensaje = "Error al obtener el rol.";
                _logger.LogError($"{rolesGetById.mensaje} {ex.ToString()}");
            }
            return rolesGetById;
        }

        public async Task<RolesSaveDto> Save(RolesSaveDto saveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                saveDto.CreatedAt = DateTime.Now;
                var rolesSave = await _baseConsumption.SaveConsumption<RolesSaveDto>("Roles/SaveRoles", saveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al guardar el rol.";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return saveDto;
        }

        public async Task<RolesUpdateDto> Update(RolesUpdateDto updateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                updateDto.UpdateAt = DateTime.Now;
                var rolesUpdate = await _baseConsumption.UpdateConsumption<RolesUpdateDto>($"Roles/UpdateRoles{updateDto.RoleID}", updateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al actualizar el rol.";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return updateDto;
        }
    }
}
