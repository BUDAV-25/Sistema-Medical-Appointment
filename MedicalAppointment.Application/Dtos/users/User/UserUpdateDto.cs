namespace MedicalAppointment.Application.Dtos.users.User
{
    public class UserUpdateDto : UserBaseDto
    {
        public int UserID { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
