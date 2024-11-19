namespace MedicalAppointment.Persistance.Models.users
{
    public class UsersModel
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
