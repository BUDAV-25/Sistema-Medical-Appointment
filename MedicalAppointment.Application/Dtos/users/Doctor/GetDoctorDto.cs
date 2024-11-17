namespace MedicalAppointment.Application.Dtos.users.Doctor
{
    public class GetDoctorDto
    {
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public short SpecialtyID { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }
        public short AvailabilityModeId { get; set; }
    }
}
