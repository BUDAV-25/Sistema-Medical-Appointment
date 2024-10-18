using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.appointments
{
    [Table("Appointments", Schema = "appointments")]
    public class Appointments : BaseEntity
    {
        [Key]
        private int AppointmentID { get; set; }
        private int PatientID { get; set; }
        private int DoctorID { get; set; }
        private DateTime AppointmentDate { get; set; }
        private int StatusID { get; set; }
    }
}
