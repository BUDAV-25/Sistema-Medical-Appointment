using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.system
{
    [Table("Roles", Schema = "system")]
    public class Roles : BaseEntity
    {
        [Key]
        private int RoleID { get; set; }
        private string? RoleName { get; set; }
    }
}
