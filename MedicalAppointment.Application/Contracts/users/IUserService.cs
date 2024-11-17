using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Application.Response.users.User;

namespace MedicalAppointment.Application.Contracts.users
{
    public interface IUserService : IBaseService<UserResponse, UserSaveDto, UserUpdateDto>
    {

    }
}
