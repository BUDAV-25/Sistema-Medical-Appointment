using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.medical;

namespace MedicalAppointment.Consumption.ModelsMethods.medical.AvailabilityModeTaskModel
{
    public class AvailabilityModeGetAllModel : BaseResponseConsumption
    {
        public List<AvailabilityModesModel> Model { get; set; }
    }
}
