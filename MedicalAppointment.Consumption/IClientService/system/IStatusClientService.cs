

using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;
using MedicalAppointment.Consumption.ModelsMethods.system.Status;

namespace MedicalAppointment.Consumption.IClientService.system
{
    public interface IStatusClientService
    {
        Task<StatusGetAllModel> GetStatus();
        Task<StatusGetByIdModel> GetStatusById();
        Task<StatusSaveDto> SaveStatus(StatusSaveDto statusSaveDto);
        Task<StatusUpdateDto> UpdateStatus(StatusUpdateDto statusUpdateDto);
    }
}
