using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.appointments
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
