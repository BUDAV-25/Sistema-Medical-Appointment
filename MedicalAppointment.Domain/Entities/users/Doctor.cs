using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.users
{
    [Table("Doctors", Schema = "users")]
    public class Doctor : BaseEntity
    {
        [Key]
        public int DoctorID { get; set; }
        public short SpecialtyID { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Bio {  get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public short AvailabilityModeId { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
    }
}
