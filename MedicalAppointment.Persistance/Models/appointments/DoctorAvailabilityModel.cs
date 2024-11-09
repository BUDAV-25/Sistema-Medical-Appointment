

namespace MedicalAppointment.Persistance.Models
{
    public sealed class DoctorAvailabilityModel
    {

        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
