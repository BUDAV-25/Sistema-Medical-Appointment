﻿namespace MedicalAppointment.Application.Dtos.users.User
{
    public class UserBaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleID { get; set; }
    }
}
