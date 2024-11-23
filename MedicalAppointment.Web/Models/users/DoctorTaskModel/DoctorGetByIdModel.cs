using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.DoctorTaskModel
{
    public class DoctorGetByIdModel : BaseProperties
    {
        public DoctorDetailsModel Model {  get; set; }
    }
}
