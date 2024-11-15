using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Application.Response.users.User;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.users
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository user_Repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUsersRepository userRepository,
                            ILogger<UserService> logger)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }
            user_Repository = userRepository;
            _logger = logger;
        }
        public async Task<UserResponse> GetAll()
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                var result = await user_Repository.GetAll();

                if (!result.Success)
                {
                    userResponse.IsSuccess = result.Success;
                    userResponse.Messages = result.Message;
                    return userResponse;
                }
                userResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                userResponse.IsSuccess = false;
                userResponse.Messages = "Error obteniendo los usuarios";
                _logger.LogError(userResponse.Messages, ex.ToString());
            }
            return userResponse;
        }
        public async Task<UserResponse> GetById(int id)
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                var result = await user_Repository.GetEntityBy(id);

                if (!result.Success)
                {
                    userResponse.IsSuccess = result.Success;
                    userResponse.Messages = result.Message;
                }
                userResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                userResponse.IsSuccess = false;
                userResponse.Messages = "Error obteniendo el usuario";
                _logger.LogError(userResponse.Messages, ex.ToString());
            }
            return userResponse;
        }
        public async Task<UserResponse> SaveAsync(UserSaveDto dto)
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                User user = new User();

                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                user.Password = dto.Password;
                user.RoleID = dto.RoleID;
                user.CreatedAt = dto.CreatedAt;
                user.IsActive = true;

                var result = await user_Repository.Save(user);
            }
            catch (Exception ex)
            {
                userResponse.IsSuccess = false;
                userResponse.Messages = "Error guardando el usuario";
                _logger.LogError(userResponse.Messages, ex.ToString());
            }
            return userResponse;
        }
        public async Task<UserResponse> UpdateAsync(UserUpdateDto dto)
        {
            UserResponse userResponse = new UserResponse();
            try
            {
                var resultEntity = await user_Repository.GetEntityBy(dto.UserID);
                if (!resultEntity.Success)
                {
                    userResponse.IsSuccess = resultEntity.Success;
                    userResponse.Messages = resultEntity.Message;
                    return userResponse;
                }
                User userToUpdate = new User();

                userToUpdate.UserID = dto.UserID;
                userToUpdate.FirstName = dto.FirstName;
                userToUpdate.LastName = dto.LastName;
                userToUpdate.Email = dto.Email;
                userToUpdate.Password = dto.Password;
                userToUpdate.RoleID = dto.RoleID;
                userToUpdate.UpdatedAt = dto.UpdatedAt;
                userToUpdate.IsActive = dto.IsActive;

                var result = await user_Repository.Update(userToUpdate);
            }
            catch (Exception ex)
            {
                userResponse.IsSuccess = false;
                userResponse.Messages = "Error actualizando el usuario";
                _logger.LogError(userResponse.Messages, ex.ToString());
            }
            return userResponse;
        }
    }
}
