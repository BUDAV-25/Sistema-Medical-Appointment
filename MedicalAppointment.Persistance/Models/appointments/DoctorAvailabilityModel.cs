

namespace MedicalAppointment.Persistance.Models
{
    public sealed class DoctorAvailabilityModel
    {

        public DateOnly AvailableDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

    }
}
