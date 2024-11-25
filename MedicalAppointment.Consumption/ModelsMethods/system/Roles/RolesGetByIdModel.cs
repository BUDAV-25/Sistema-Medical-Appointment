

using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Roles
{
    public class RolesGetByIdModel : BaseResponseConsumption
    {
        public RolesModel data { get; set; }
    }
}
