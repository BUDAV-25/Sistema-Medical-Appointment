namespace MedicalAppointment.Application.Dtos.users.Doctor
{
    public class DoctorUpdateDto : DoctorBaseDto
    {
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
