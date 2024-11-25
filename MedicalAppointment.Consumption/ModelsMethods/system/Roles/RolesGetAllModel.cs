

using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Roles
{
    public class RolesGetAllModel : BaseResponseConsumption
    {
        public List<RolesModel> data { get; set; }
    }
}
