namespace MedicalAppointment.Persistance.Models.medical
{
    public class AvailabilityModesModel
    {
        public short SAvailabilityModeID { get; set; }
        public string? AvailabilityMode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
