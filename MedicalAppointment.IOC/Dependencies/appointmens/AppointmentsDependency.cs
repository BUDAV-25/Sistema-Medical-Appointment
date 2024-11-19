

using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Services.appointmet;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Repositories.appointments;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.IOC.Dependencies.appointmens
{
    public static class AppointmentsDependency
    {
        public static void AddAppointmentsDependency(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();

            services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

            services.AddTransient<IAppointmentsService, AppointmentService>();

            services.AddTransient<IDoctorAvailabilityService, DoctorAvailabilityService>();
        }
    }
}
