using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.SpecialtiesTaskModel
{
    public class SpecialtiesGetByIdModel : BaseResponseConsumption
    {
        public SpecialtiesModel Model { get; set; }
    }
}
