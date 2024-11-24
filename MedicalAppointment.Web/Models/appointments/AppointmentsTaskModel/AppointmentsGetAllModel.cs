
using MedicalAppointment.Persistance.Models.appointments;
using MedicalAppointment.Web.Models.Core;

namespace MedicalAppointment.Web.Models.appointments.AppointmentsTaskModel
{
    public class AppointmentsGetAllModel : BaseProperties
    {
        public List<AppointmentsModel> data { get; set; }

    }
}
