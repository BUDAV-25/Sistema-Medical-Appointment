using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.medical.AvailabilityModeTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.medical
{
    public interface IAvailabilityModesContract : Interfaces<AvailabilityModeGetAllModel, AvailabilityModesGetByIdModel,
        AvailabilityModesSaveDto, AvailabilityModesUpdateDto>
    {
    }
}
