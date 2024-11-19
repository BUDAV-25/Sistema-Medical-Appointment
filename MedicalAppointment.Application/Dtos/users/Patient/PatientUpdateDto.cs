namespace MedicalAppointment.Application.Dtos.users.Patient
{
    public class PatientUpdateDto : PatientBaseDto
    {
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
