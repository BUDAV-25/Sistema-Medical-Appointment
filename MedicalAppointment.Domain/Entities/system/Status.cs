using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.system
{
    [Table("Status", Schema = "system")]
    public class Status
    {
        [Key]
        private int StatusID { get; set; }
        private string? StatusName { get; set; }
    }
}
