

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Application.Response.appointments.DoctorAvailability;

namespace MedicalAppointment.Application.Contracts.appointments
{
    public interface IDoctorAvailabilityService : IBaseService<DoctorAvailabilityResponse, DoctorAvailabilitySaveDto, DoctorAvailabilityUpdateDto>
    {
    }
}
