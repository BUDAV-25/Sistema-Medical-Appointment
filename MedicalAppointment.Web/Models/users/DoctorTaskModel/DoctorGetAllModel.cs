using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.DoctorTaskModel
{
    public class DoctorGetAllModel : BaseProperties
    {
        public List<DoctorDetailsModel> Model {  get; set; }
    }
}
