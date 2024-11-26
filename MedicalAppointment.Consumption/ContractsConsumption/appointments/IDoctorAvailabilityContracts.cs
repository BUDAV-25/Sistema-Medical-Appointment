using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.appointments.DoctorAvailability;

namespace MedicalAppointment.Consumption.ContractsConsumption.appointments
{
    public interface IDoctorAvailabilityContracts : Interfaces<DoctorAvailabilityGetAllModel, DoctorAvailabilityGetByIdModel, DoctorAvailabilitySaveDto, DoctorAvailabilityUpdateDto>
    {
    }
}
