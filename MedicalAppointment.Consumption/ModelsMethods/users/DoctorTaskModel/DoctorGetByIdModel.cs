using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.Models.users.DoctorTaskModel
{
    public class DoctorGetByIdModel : BaseResponseConsumption
    {
        public DoctorDetailsModel Model {  get; set; }
    }
}
