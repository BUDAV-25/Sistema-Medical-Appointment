using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.system
{
    [Table("Notifications", Schema = "system")]
    public class Notifications
    {
        [Key]
        private int NotificationID { get; set; }
        private int UserID {get;set;}
        private string? Message {get;set;}
        private DateTime? SentAt { get;set;}
    }
}
