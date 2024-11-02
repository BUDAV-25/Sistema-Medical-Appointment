using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.users
{
    public sealed class UsersRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<UsersRepository> logger) : BaseRepository<Users>(medicalAppointmentContext), IUsersRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<UsersRepository> logger = logger;
        public async override Task<OperationResult> Save(Users entity)
        {
            OperationResult result = new OperationResult();
            if(entity == null)
                {
                    result.Success = false;
                    result.Message = "Se requiere la entidad";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.FirstName))
                {
                    result.Success = false;
                    result.Message = "Es requerido el nombre del usuario";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.LastName))
                {
                    result.Success = false;
                    result.Message = "Requerimos el apellido";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.Email))
                {
                    result.Success = false;
                    result.Message = "Necesitamos el e-mail del usuario";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.Password))
                {
                    result.Success = false;
                    result.Message = "Por seguridad, se requiere una contraseña";
                    return result;
                }
                if(await base.Exists(user => user.UserID == entity.UserID))
                {
                    result.Success = false;
                    result.Message = "El usuario ya est[a registrado";
                    return result;
                }
            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al guardar el usuario";
                logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }
        public async override Task<OperationResult> Update(Users entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
                {
                    result.Success = false;
                    result.Message = "Se requiere la entidad";
                    return result;
                }
                if(entity.UserID <= 0)
                {
                    result.Success = false;
                    result.Message = "Es necesario el id de usuario para realizar esta función";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.FirstName))
                {
                    result.Success = false;
                    result.Message = "Es requerido el nombre del usuario";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.LastName))
                {
                    result.Success = false;
                    result.Message = "Requerimos el apellido";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.Email))
                {
                    result.Success = false;
                    result.Message = "Necesitamos el e-mail del usuario";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.Password))
                {
                    result.Success = false;
                    result.Message = "Por seguridad, se requiere una contraseña";
                    return result;
                }
            try
            {
                Users? userToUpdate = await medical_AppointmentContext.Users.FindAsync(entity.UserID);
                userToUpdate.FirstName = entity.FirstName;
                userToUpdate.LastName = entity.LastName;
                userToUpdate.Email = entity.Email;
                userToUpdate.Password = entity.Password;
                userToUpdate.RoleID = entity.RoleID;
                userToUpdate.UserUpdate = entity.UserUpdate;

                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el usuario";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(Users entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
                {
                    result.Success = false;
                    result.Message = "Se requiere la entidad";
                    return result;
                }
                if (entity.UserID <= 0)
                {
                    result.Success = false;
                    result.Message = "Es necesario el id de usuario para realizar esta función";
                    return result;
                }
            try
            {
                Users? userToRemove = await medical_AppointmentContext.Users.FindAsync(entity.UserID);
                userToRemove.IsActive = false;
                userToRemove.UpdatedAt = entity.UpdatedAt;
                userToRemove.UserUpdate = entity.UserUpdate;

                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error desactivando el usuario";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from user in medical_AppointmentContext.Users
                                     join role in medical_AppointmentContext.Roles on user.RoleID equals role.RoleID
                                     where user.IsActive == true
                                     select new UsersModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         RoleName = role.RoleName
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los usuarios";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from user in medical_AppointmentContext.Users
                                     join role in medical_AppointmentContext.Roles on user.RoleID equals role.RoleID
                                     where user.IsActive == true
                                     && user.UserID == Id
                                     select new UsersModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         RoleName = role.RoleName
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el usuario";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> FindUserRole(int roleId)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from user in medical_AppointmentContext.Users
                                     join role in medical_AppointmentContext.Roles on user.RoleID equals role.RoleID
                                     where user.IsActive == true
                                     && user.RoleID == roleId
                                     select new UsersModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         RoleName = role.RoleName
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los usuarios";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
