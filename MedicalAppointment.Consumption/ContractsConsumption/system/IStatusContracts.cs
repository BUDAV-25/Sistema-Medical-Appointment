using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.system.Status;

namespace MedicalAppointment.Consumption.ContractsConsumption.system
{
    public interface IStatusContracts : Interfaces <StatusGetAllModel, StatusGetByIdModel, StatusSaveDto, StatusUpdateDto>
    {
    }
}
