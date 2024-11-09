using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.medical
{
    [Table("Specialties", Schema = "medical")]
    public class Specialties : BaseEntity
    {
        [Key]
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }
    }
}
