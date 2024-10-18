using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.appointments
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class DoctorAvailability
    {
        private int AvailabilityID { get; set; }
        private int DoctorID { get; set; }
        private DateOnly AvailableDate { get; set; }
        private TimeOnly StartTime { get; set; }
        private TimeOnly EndTime { get; set;}
    }
}
