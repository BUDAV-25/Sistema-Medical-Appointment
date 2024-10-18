using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.medical
{
    [Table("MedicalRecords", Schema = "medical")]
    public class MedicalRecords : BaseEntity
    {
        [Key]
        private int RecordID { get; set; }
        private int PatientID { get; set; }
        private int DoctorID { get; set; }
        private string? Diagnosis {  get; set; }
        private string? Treatment { get; set; }
        private DateTime? DateOfVisit { get; set; }
    }
}
