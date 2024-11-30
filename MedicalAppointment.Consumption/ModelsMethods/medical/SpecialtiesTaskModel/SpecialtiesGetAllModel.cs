using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.SpecialtiesTaskModel
{
    public class SpecialtiesGetAllModel : BaseResponseConsumption
    {
        public List<SpecialtiesModel> Model { get; set; }
    }
}
