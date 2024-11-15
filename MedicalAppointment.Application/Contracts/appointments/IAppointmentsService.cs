

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Application.Response.appointments.Appointments;

namespace MedicalAppointment.Application.Contracts.appointments
{
    public interface IAppointmentsService : IBaseService<AppointmentsResponse, AppointmentsSaveDto, AppointmentsUpdateDto>
    {
    }
}
