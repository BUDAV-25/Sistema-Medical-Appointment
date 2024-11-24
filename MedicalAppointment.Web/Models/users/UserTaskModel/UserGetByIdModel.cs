using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.UserTaskModel
{
    public class UserGetByIdModel : BaseProperties
    {
        public UsersModel Model { get; set; }
    }
}
