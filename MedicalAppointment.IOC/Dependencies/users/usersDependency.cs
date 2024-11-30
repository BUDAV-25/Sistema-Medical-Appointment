﻿using Microsoft.Extensions.DependencyInjection;
using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Services.users;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Repositories.users;
using MedicalAppointment.Persistance.Repositories.Validations;

namespace MedicalAppointment.IOC.Dependencies.users
{
    public static class usersDependency
    {
        public static void AddUsersDependency(this IServiceCollection service)
        {
            service.AddScoped<IDoctorRepository, DoctorRepository>();
            service.AddScoped<IPatientRepository, PatientsRepository>();
            service.AddScoped<IUsersRepository, UsersRepository>();

            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IDoctorService, DoctorService>();
            service.AddTransient<IPatientService, PatientService>();

            service.AddScoped<ValidateUsers>();
        }
    }
}
