

namespace MedicalAppointment.Persistance.Models
{
    public sealed class DoctorAvailabilityModel
    {
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
