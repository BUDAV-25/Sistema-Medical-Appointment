namespace MedicalAppointment.Application.Dtos.medical.MedicalRecords
{
    public class MedicalRecordsUpdateDto : MedicalRecordsBaseDto
    {
        public int RecordID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
