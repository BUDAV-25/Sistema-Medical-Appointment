

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Response.system.Roles;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.System
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly ILogger<RolesService> _logger;
        private readonly IRolesService _rolesService;

        public RolesService(IRolesRepository rolesRepository, ILogger<RolesService> logger)
        {
            if (rolesRepository is null)
            {
                throw new ArgumentNullException(nameof(rolesRepository));
            }

            _rolesRepository = rolesRepository;
            _logger = logger;
        }
        public async Task<RolesResponse> GetAll()
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var result = await _rolesRepository.GetAll();

                if (!result.Success)
                {
                    rolesResponse.Messages = result.Message;
                    rolesResponse.IsSuccess = result.Success;
                    return rolesResponse;
                }

                rolesResponse.Data = result.Data;

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error obteniendo los roles";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;
        }

        public async Task<RolesResponse> GetById(int id)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var result = await _rolesRepository.GetEntityBy(id);

                if (!result.Success)
                {
                    rolesResponse.Messages = result.Message;
                    rolesResponse.IsSuccess = result.Success; 
                    
                    return rolesResponse;
                }

                rolesResponse.Data= result.Data;

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error obteniendo el RoleID";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;
        }

        public async Task<RolesResponse> SaveAsync(RolesSaveDto dto)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                Roles roles = new Roles();

                roles.RoleName = dto.RoleName;
                roles.CreatedAt = dto.CreatedAt;

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

        public async Task<RolesResponse> UpdateAsync(RolesUpdateDto dto)
        {
            RolesResponse rolesResponse = new RolesResponse();

            try
            {
                var resultGetById = await _rolesRepository.GetEntityBy(dto.RoleID);

                if (!resultGetById.Success)
                {
                    rolesResponse.IsSuccess = resultGetById.Success;
                    rolesResponse.Messages = resultGetById.Message;

                    return rolesResponse;
                }

                Roles roles = new Roles();

                roles.RoleID = dto.RoleID;
                roles.RoleName = dto.RoleName;
                roles.UpdatedAt = dto.UpdateAt;
                roles.IsActive = dto.IsActive;
                
                var result = await _rolesRepository.Update(roles);

            }
            catch (Exception ex)
            {
                rolesResponse.IsSuccess = false;
                rolesResponse.Messages = "Error actualizando el rol";
                _logger.LogError(rolesResponse.Messages, ex.ToString());
            }
            return rolesResponse;
        }
    }
}



