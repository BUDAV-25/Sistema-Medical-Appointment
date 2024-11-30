using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Web.ModelsMethods.users.UserTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.users
{
    public interface IUserContract : Interfaces<UserGetAllModel, UserGetByIdModel, UserSaveDto, UserUpdateDto>
    {
    }
}
