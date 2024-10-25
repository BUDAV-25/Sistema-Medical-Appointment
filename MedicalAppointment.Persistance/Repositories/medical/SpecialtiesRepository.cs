using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.medical
{
    public sealed class SpecialtiesRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<SpecialtiesRepository> logger) : BaseRepository<Specialties>(medicalAppointmentContext), ISpecialtiesRepository
    {
        private readonly MedicalAppointmentContext medicalAppointmentContext = medicalAppointmentContext;
        private readonly ILogger<SpecialtiesRepository> logger = logger;
    }
}
