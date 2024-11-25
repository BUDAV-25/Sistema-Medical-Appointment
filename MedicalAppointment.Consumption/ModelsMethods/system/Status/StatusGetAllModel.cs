

using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Status
{
    public class StatusGetAllModel : BaseResponseConsumption
    {
        public List<StatusModel> data { get; set; }
    }
}
