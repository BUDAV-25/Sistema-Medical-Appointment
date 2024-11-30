using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.users;

namespace MedicalAppointment.Web.Models.users.DoctorTaskModel
{
    public class DoctorGetAllModel : BaseResponseConsumption
    {
        public List<DoctorDetailsModel> Model {  get; set; }
    }
}
