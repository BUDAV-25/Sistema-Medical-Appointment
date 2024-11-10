

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Application.Response.appointments.DoctorAvailability;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.Appointment
{
    public class DoctorAvailabilityService : IBaseService<DoctorAvailabilityResponse, DoctorAvailabilitySaveDto, DoctorAvailabilityUpdateDto>
    {
        private readonly IDoctorAvailabilityRepository doctorAvailabilityRepository;
        private readonly ILogger _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository, ILogger<DoctorAvailabilityService> logger) { 
        }
        public Task<DoctorAvailabilityResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAvailabilityResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAvailabilityResponse> SaveAsync(DoctorAvailabilitySaveDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAvailabilityResponse> UpdateAsync(DoctorAvailabilityUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
