using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.system
{
    [Table("Notifications", Schema = "system")]
    public class Notifications
    {
        [Key]
        public int NotificationID { get; set; }
        public int UserID {get;set;}
        public string? Message {get;set;}
        public DateTime? SentAt { get;set;}
    }
}
