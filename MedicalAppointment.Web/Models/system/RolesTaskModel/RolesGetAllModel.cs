using MedicalAppointment.Persistance.Models.system;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.system.RolesTaskModel
{
    public class RolesGetAllModel : BaseProperties
    {
        public List<RolesModel> data { get; set; }

    }
}
