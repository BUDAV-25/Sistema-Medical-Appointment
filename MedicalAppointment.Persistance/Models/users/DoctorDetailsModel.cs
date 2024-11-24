namespace MedicalAppointment.Persistance.Models.users
{
    public class DoctorDetailsModel
    {
        public int DoctorID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }
        public string? Email { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public short AvailabilityModeId { get; set; }
        public string? AvailabilityMode { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
