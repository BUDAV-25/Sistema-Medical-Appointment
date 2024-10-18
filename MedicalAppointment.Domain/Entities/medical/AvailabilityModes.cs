using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.medical
{
    [Table("AvailabilityModes", Schema = "medical")]
    public class AvailabilityModes : BaseEntity
    {
        [Key]
        private short SAvailabilityModeID {  get; set; }
        private string? AvailabilityMode {  get; set; }
    }
}
