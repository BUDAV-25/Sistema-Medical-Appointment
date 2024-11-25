

using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Persistance.Models;

namespace MedicalAppointment.Consumption.ModelsMethods.appointments.DoctorAvailability
{
    public class DoctorAvailabilityGetAllModel : BaseResponseConsumption
    {
        public List<DoctorAvailabilityModel> data { get; set; }

    }
}
