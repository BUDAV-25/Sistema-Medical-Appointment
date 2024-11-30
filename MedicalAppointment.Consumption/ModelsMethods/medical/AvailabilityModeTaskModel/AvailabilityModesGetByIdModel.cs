using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.AvailabilityModeTaskModel
{
    public class AvailabilityModesGetByIdModel : BaseResponseConsumption
    {
        public AvailabilityModesModel Model { get; set; }
    }
}
