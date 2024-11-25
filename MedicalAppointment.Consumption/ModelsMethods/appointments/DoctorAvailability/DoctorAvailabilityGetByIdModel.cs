
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models;

namespace MedicalAppointment.Consumption.ModelsMethods.appointments.DoctorAvailability
{
    public class DoctorAvailabilityGetByIdModel : BaseResponseConsumption
    {
        public DoctorAvailabilityModel data { get; set; }

    }
}
