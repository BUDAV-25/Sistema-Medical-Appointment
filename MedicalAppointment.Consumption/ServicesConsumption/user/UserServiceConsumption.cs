using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Web.ModelsMethods.users.UserTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.user
{
    public class UserServiceConsumption : IUserContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<UserServiceConsumption> _logger;
        public UserServiceConsumption(IBaseConsumption baseConsumption, ILogger<UserServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<UserGetAllModel> GetAll()
        {
            UserGetAllModel userGetAllModel = new UserGetAllModel();
            try
            {
                userGetAllModel = await base_Consumption.GetAllConsumption<UserGetAllModel>("User/GetAllUsers");
            }
            catch (Exception ex)
            {
                userGetAllModel.isOkay = false;
                userGetAllModel.mensaje = "Error obteniendo los usuarios";
                _logger.LogError(userGetAllModel.mensaje, ex.ToString());
            }
            return userGetAllModel;
        }
        public async Task<UserGetByIdModel> GetById(int id)
        {
            UserGetByIdModel userGetByIdModel = new UserGetByIdModel();
            try
            {
                userGetByIdModel = await base_Consumption.GetByIdConsumption<UserGetByIdModel>($"User/GetUserBy{id}");
            }
            catch (Exception ex)
            {
                userGetByIdModel.isOkay = false;
                userGetByIdModel.mensaje = "Error obteniendo el usuario";
                _logger.LogError(userGetByIdModel.mensaje, ex.ToString());
            }
            return userGetByIdModel;
        }
        public async Task<UserSaveDto> Save(UserSaveDto userSave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                userSave.CreatedAt = DateTime.Now;
                var response = await base_Consumption.SaveConsumption<UserSaveDto>("User/SaveUser", userSave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando el Usuario";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return userSave;
        }
        public async Task<UserUpdateDto> Update(UserUpdateDto userUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                userUpdate.UpdatedAt = DateTime.Now;
                var response = await base_Consumption.UpdateConsumption<UserUpdateDto>("User/UpdateUser", userUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando el Usuario";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return userUpdate;
        }
    }
}
