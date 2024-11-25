
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Status
{
    public class StatusGetByIdModel : BaseResponseConsumption
    {
        public StatusModel data { get; set; }
    }
}
