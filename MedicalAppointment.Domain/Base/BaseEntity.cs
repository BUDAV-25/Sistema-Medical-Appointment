namespace MedicalAppointment.Domain.Base
{
    public abstract class BaseEntity
    {

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
