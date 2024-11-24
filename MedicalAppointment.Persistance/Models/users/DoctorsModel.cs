namespace MedicalAppointment.Persistance.Models.users
{
    public class DoctorsModel
    {
        public int DoctorID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SpecialtyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Education { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public string? AvailabilityMode { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
    }
}
