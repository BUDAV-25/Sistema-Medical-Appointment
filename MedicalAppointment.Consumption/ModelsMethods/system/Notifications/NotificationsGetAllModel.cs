using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Notifications
{
    public class NotificationsGetAllModel : BaseResponseConsumption
    {
        public List<NotificationsModel> data { get; set; }

    }
}
