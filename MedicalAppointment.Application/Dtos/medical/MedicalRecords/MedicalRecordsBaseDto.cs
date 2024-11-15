namespace MedicalAppointment.Application.Dtos.medical.MedicalRecords
{
    public class MedicalRecordsBaseDto
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public DateTime? DateOfVisit { get; set; }
    }
}
