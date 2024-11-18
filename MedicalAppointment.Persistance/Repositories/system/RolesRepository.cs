using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.system
{
    public sealed class RolesRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<RolesRepository> logger) : BaseRepository<Roles>(medicalAppointmentContext), IRolesRepository
    {

        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<RolesRepository> logger = logger;

        public async override Task<OperationResult> Save(Roles entity)
        {

            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(entity.RoleName) || entity.RoleName.Length > 50)
            {
                result.Success = false;
                result.Message = "Debe de tener un nombre con un maximo de 50 caracteres";
                return result;
            }

            try
            {
                await base.Save(entity);
                result.Data = entity;
                result.Message = "Rol guardado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el Rol";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Update(Roles entity)
        {

            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (string.IsNullOrEmpty(entity.RoleName) || entity.RoleName.Length > 50)
            {
                result.Success = false;
                result.Message = "Debe de tener un nombre con un maximo de 50 caracteres";
                return result;
            }
            if (entity.UpdatedAt == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha de modificacion";
                return result;
            }
            if (entity.IsActive == null)
            {

                result.Success = false;
                result.Message = "Se requiere la activacion";
                return result;
            }

            try
            {
                Roles? rolesToUpdate = await medical_AppointmentContext.Roles.FindAsync(entity.RoleID);

                rolesToUpdate.RoleName = entity.RoleName;
                rolesToUpdate.UpdatedAt = entity.UpdatedAt;
                rolesToUpdate.IsActive = entity.IsActive;

                result = await base.Update(rolesToUpdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el rol";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Remove(Roles entity)
        {

            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (entity.RoleID <= 0)
            {
                result.Success = false;
                result.Message = "Se requiere el RoleID";
                return result;
            }

            try
            {
                Roles? rolesToRemove = await medical_AppointmentContext.Roles.FindAsync(entity.RoleID);

                rolesToRemove.RoleID = entity.RoleID;
                rolesToRemove.RoleName = entity.RoleName;
                rolesToRemove.CreatedAt = entity.CreatedAt;
                rolesToRemove.UpdatedAt = entity.UpdatedAt;
                rolesToRemove.IsActive = entity.IsActive;

                await base.Update(rolesToRemove);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover el rol";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }


        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from role in medical_AppointmentContext.Roles
                                     orderby role.RoleID descending

                                     select new RolesModel()
                                     {
                                         RoleID = role.RoleID,
                                         RoleName = role.RoleName,
                                         CreatedAt = role.CreatedAt,
                                         UpdatedAt = role.UpdatedAt,
                                         IsActive = role.IsActive

                                     }).AsNoTracking()
                                     .ToListAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> GetEntityBy(int ID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from role in medical_AppointmentContext.Roles
                                     where role.RoleID == ID
                                     select new RolesModel()
                                     {
                                         RoleID = role.RoleID,
                                         RoleName = role.RoleName,
                                         CreatedAt = role.CreatedAt,
                                         UpdatedAt = role.UpdatedAt,
                                         IsActive = role.IsActive

                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public Task<OperationResult> AssignRoleToUser(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> CreateRole(string roleName, List<string> permissions)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetPermissionsByRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> RemoveRoleFromUser(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
