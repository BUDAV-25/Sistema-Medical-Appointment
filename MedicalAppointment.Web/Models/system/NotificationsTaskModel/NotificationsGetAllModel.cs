using MedicalAppointment.Persistance.Models.system;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.system.NotificationsTaskModel
{
    public class NotificationsGetAllModel : BaseProperties
    {
        public List<NotificationsModel> data { get; set; }

    }
}
