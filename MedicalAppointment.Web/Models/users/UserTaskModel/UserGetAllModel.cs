using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.UserTaskModel
{
    public class UserGetAllModel : BaseProperties
    {
        public List<UsersModel> Model { get; set; }
    }
}
