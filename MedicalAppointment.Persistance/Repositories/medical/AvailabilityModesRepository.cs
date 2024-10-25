using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.medical
{
    public sealed class AvailabilityModesRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<AvailabilityModesRepository> logger) : BaseRepository<AvailabilityModes>(medicalAppointmentContext), IAvailabilityModesRepository
    {
        private readonly MedicalAppointmentContext medicalAppointmentContext = medicalAppointmentContext;
        private readonly ILogger<AvailabilityModesRepository> logger = logger;
    }
}
