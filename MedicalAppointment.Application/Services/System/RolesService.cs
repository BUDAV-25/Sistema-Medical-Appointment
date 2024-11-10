

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Response.system.Roles;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.System
{
    public class RolesService : IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>
    {
        private readonly IRolesRepository _rolesRepository;
        private ILogger _logger;
        public RolesService(IRolesRepository rolesRepository, ILogger logger)
        {
            if (rolesRepository is null)
            {
                throw new ArgumentNullException(nameof(rolesRepository));
                
            }

            this._rolesRepository= rolesRepository;
            this._logger = logger;
        }

        async Task<RolesResponse> IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>.GetAll()
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var result = await _rolesRepository.GetAll();

                List<RolesGetDto> roles = ((List<Roles>)result.Data).Select(roles => new RolesGetDto()
                {
                    RoleID = roles.RoleID,
                    RoleName = roles.RoleName,
                }).ToList();

                rolesResponse.IsSuccess = result.Success;
                rolesResponse.Model = roles;

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error obteniendo los roles";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;

        }

        async Task<RolesResponse> IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>.GetById(int id)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var result = await _rolesRepository.GetEntityBy(id);

                Roles roles = (Roles)result.Data;

                RolesGetDto rolesGetDto = new RolesGetDto()
                {
                    RoleID = roles.RoleID,
                    RoleName = roles.RoleName
                };
                rolesResponse.IsSuccess = result.Success;
                rolesResponse.Model = rolesGetDto;

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess= false;
                rolesResponse.Messages = "Error obteniendo el RoleID";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;
        }

        async Task<RolesResponse> IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>.SaveAsync(RolesSaveDto dto)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                Roles roles = new Roles();

                roles.RoleID = dto.RoleID;
                roles.RoleName = dto.RoleName;
                roles.CreatedAt = dto.CreateTime;
                roles.IsActive = dto.IsActive;

                var result = await _rolesRepository.Save(roles);

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error guardando el Rol";
                _logger.LogError(rolesResponse.Messages, ex.ToString());

            }
            return rolesResponse;
        }

        async Task<RolesResponse> IBaseService<RolesResponse, RolesSaveDto, RolesUpdateDto>.UpdateAsync(RolesUpdateDto dto)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var resultEntity = await _rolesRepository.GetEntityBy(dto.RoleID);

                Roles rolesToUpdate = (Roles)resultEntity.Data;

                rolesToUpdate.RoleID = dto.RoleID;
                rolesToUpdate.RoleName = dto.RoleName;
                rolesToUpdate.UpdatedAt = dto.UpdateAt;
                rolesToUpdate.IsActive = dto.IsActive;

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error actualizando el Rol";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;
        }
    }
}
