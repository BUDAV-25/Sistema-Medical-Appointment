namespace MedicalAppointment.Domain.Base
{
    public abstract class BaseEntity
    {
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private bool IsActive { get; set; }
    }
}
