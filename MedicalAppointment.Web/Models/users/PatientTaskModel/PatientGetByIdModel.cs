using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.users.PatientTaskModel
{
    public class PatientGetByIdModel : BaseProperties
    {
        public UserPatientModel Model { get; set; }
    }
}
