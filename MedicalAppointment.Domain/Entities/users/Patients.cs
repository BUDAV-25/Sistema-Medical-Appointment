using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.users
{
    [Table("Patients", Schema = "users")]
    public class Patients : BaseEntity
    {
        [Key]
        private int PatientID { get; set; }
        private DateOnly? DateOfBirth { get; set; }
        private char? Gender { get; set; }
        private string? PhoneNumber { get; set; }
        private string? Address { get; set; }
        private string? EmergencyContactName { get; set; }
        private string? EmergencyContactPhone { get; set; }
        private char? BloodType { get; set; }
        private string? Allergies { get; set; }
        private int InsuranceProviderID { get; set; }
    }
}
