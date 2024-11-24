using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Repositories.system;
using Microsoft.Extensions.DependencyInjection;
using MedicalAppointment.Consumption.ServicesConsumption.system;

namespace MedicalAppointment.IOC.Dependencies.system
{
    public static class SystemDependency
    {
        public static void AddSystemDependency(this IServiceCollection service)
        {
            service.AddScoped<INotificationsRepository, NotificationsRepository>();

            service.AddScoped<IRolesRepository, RolesRepository>();

            service.AddScoped<IStatusRepository, StatusRepository>();

            service.AddTransient<IStatusService, StatusService>();

            service.AddTransient<IRolesService, RolesService>();

            service.AddTransient<INotificationService, NotificationService>();

        }
    }
}
