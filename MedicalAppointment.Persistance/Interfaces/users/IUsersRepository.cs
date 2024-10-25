﻿using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Repositories;

namespace MedicalAppointment.Persistance.Interfaces.users
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        public void FindUserRole(int roleId);
    }
}