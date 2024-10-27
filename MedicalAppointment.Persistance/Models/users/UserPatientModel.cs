namespace MedicalAppointment.Persistance.Models.users
{
    public class UserPatientModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public char? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public char? BloodType { get; set; }
    }
}
