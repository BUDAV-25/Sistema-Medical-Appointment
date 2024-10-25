using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.system
{
    [Table("Status", Schema = "system")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
    }
}
