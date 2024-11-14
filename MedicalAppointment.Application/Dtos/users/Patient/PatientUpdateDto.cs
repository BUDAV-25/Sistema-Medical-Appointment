namespace MedicalAppointment.Application.Dtos.users.Patient
{
    public class PatientUpdateDto : PatientBaseDto
    {
        public int PatientID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
