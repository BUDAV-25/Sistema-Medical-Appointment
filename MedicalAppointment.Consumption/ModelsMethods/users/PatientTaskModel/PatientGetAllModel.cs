using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.ModelsMethods.users.PatientTaskModel
{
    public class PatientGetAllModel : BaseResponseConsumption
    {
        public List<UserPatientModel> Model { get; set; }
    }
}
