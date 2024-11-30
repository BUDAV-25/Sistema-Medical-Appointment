using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.ModelsMethods.users.UserTaskModel
{
    public class UserGetAllModel : BaseResponseConsumption
    {
        public List<UsersModel> Model { get; set; }
    }
}
