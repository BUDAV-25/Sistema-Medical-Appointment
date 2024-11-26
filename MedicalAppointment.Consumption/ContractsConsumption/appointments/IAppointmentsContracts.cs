using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.appointments.Appointments;

namespace MedicalAppointment.Consumption.ContractsConsumption.appointments
{
    public interface IAppointmentsContracts : Interfaces<AppointmentsGetAllModel, AppointmentsGetByIdModel, AppointmentsSaveDto, AppointmentsUpdateDto>
    {
    }
}
