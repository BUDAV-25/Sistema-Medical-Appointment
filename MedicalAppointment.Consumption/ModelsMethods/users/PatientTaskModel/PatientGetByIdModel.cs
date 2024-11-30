using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.ModelsMethods.users.PatientTaskModel
{
    public class PatientGetByIdModel : BaseResponseConsumption
    {
        public UserPatientModel Model { get; set; }
    }
}
