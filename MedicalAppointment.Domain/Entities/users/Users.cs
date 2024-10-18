using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.users
{
    [Table("Users", Schema = "users")]
    public class Users : BaseEntity
    {
        [Key]
        private int UserID { get; set; }
        private string? FirstName { get; set; }
        private string? LastName { get; set;}
        private string? Email { get; set; }
        private string? Password { get; set; }
        private int RoleID { get; set; }
    }
}
