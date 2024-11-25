using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models.appointments;

namespace MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments
{
    public class AppointmentsGetByIdModel : BaseResponseConsumption
    {
        public AppointmentsModel data { get; set; }

    }
}
