namespace MedicalAppointment.Persistance.Models.users
{
    public class UserPatientModel
    {
        public int PatientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public char? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public char? BloodType { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? Allergies { get; set; }
        public int InsuranceProviderID { get; set; }
        public string? InsuranceProviderName { get; set; }
        public bool IsActive { get; set; }
    }
}
