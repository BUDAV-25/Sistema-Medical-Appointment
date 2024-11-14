

namespace MedicalAppointment.Application.Dtos.system.Roles
{
    public class RolesBaseDto
    {
        public string? RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }

    }
}
