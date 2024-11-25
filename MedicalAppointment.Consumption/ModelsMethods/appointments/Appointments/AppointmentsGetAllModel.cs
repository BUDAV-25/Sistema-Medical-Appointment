using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.appointments;

namespace MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments
{
    public class AppointmentsGetAllModel : BaseResponseConsumption
    {
        public List<AppointmentsModel> data { get; set; }

    }
}
