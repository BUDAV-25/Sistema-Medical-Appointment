using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.ModelsMethods.users.UserTaskModel
{
    public class UserGetByIdModel : BaseResponseConsumption
    {
        public UsersModel Model { get; set; }
    }
}
