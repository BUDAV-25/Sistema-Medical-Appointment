using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.PatientTaskModel
{
    public class PatientGetAllModel : BaseProperties
    {
        public List<UserPatientModel> Model { get; set; }
    }
}
