namespace MedicalAppointment.Application.Dtos.medical.Specialties
{
    public class SpecialtiesUpdateDto : SpecialtiesBaseDto
    {
        public short SpecialtyID { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
