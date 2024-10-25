using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.medical
{
    [Table("AvailabilityModes", Schema = "medical")]
    public class AvailabilityModes : BaseEntity
    {
        [Key]
        public short SAvailabilityModeID {  get; set; }
        public string? AvailabilityMode {  get; set; }
    }
}
