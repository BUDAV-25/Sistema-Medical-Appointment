namespace MedicalAppointment.Application.Dtos.users.Doctor
{
    public class DoctorUpdateDto : DoctorBaseDto
    {
        public int DoctorID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
