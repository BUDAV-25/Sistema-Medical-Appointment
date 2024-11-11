using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Dependencies.System
{
    public static class StatusDependency
    {
        public static void AddStatusDependency(this IServiceCollection service)
        {
            service.AddScoped<INotificationsRepository, NotificationsRepository>();

            service.AddScoped<IRolesRepository, RolesRepository>();

            service.AddScoped<IStatusRepository, StatusRepository>();

            service.AddTransient<IStatusService, StatusService>();
        }
    }
}
