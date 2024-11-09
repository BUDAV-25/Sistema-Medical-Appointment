

namespace MedicalAppointment.Application.Dtos.system.Roles
{
    public class RolesBaseDto
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsActive { get; set; }

    }
}
