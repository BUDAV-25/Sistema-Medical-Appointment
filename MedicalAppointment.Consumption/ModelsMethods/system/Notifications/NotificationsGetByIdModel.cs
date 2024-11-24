using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Consumption.ModelsMethods.system.Notifications
{
    public class NotificationsGetByIdModel : BaseResponseConsumption
    {
        public NotificationsModel data { get; set; }

    }
}
