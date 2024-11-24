namespace MedicalAppointment.Application.Dtos.medical.AvailabilityModes
{
    public class AvailabilityModesUpdateDto : AvailabilityModesBaseDto
    {
        public int SAvailabilityModeID { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
