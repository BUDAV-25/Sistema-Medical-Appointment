using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Insurance
{
    [Table("NetworkType", Schema = "Insurance")]
    public class NetworkType : BaseEntity
    {
        [Key]
        private int NetworkTypeId { get; set; }
        private string? Name { get; set; }
        private string? Description { get; set; }
    }
}
