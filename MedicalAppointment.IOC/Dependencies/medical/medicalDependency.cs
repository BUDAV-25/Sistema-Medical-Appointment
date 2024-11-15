using Microsoft.Extensions.DependencyInjection;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Repositories.medical;
using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Services.medical;

namespace MedicalAppointment.IOC.Dependencies.medical
{
    public static class medicalDependency
    {
        public static void AddMedicalDependency(this IServiceCollection service)
        {
            service.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            service.AddScoped<IMedicalRecordsRepository, MedicalRecordsRepository>();
            service.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();

            service.AddTransient<IAvailabilityModesService, AvailabilityModesService>();
            service.AddTransient<IMedicalRecordsService, MedicalRecordsService>();
            service.AddTransient<ISpecialtiesService,  SpecialtiesService>();
        }
    }
}
