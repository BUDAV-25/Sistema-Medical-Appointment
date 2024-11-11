

namespace MedicalAppointment.Application.Dtos.appointments.DoctorAvailability
{
    public class DoctorAvailabilityBaseDto
    {
        public int DoctorID { get; set; }
        public DateTime? AvailableDate { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
