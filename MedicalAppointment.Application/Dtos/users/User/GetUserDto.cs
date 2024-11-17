namespace MedicalAppointment.Application.Dtos.users.User
{
    public class GetUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
