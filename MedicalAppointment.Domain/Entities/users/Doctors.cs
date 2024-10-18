using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.users
{
    [Table("Doctors", Schema = "users")]
    public class Doctors
    {
        [Key]
        private int DoctorID { get; set; }
        private short SpecialtyID { get; set; }
        private string? LicenseNumber { get; set; }
        private string? PhoneNumber { get; set; }
        private int YearsOfExperience { get; set; }
        private string? Education { get; set; }
        private string? Bio {  get; set; }
        private decimal? ConsultationFee { get; set; }
        private string? ClinicAddress { get; set; }
        private short AvailabilityModeId { get; set; }
        private DateOnly? LicenseExpirationDate { get; set; }
    }
}
