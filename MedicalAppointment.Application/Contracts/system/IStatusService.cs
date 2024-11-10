using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Application.Response.system.Status;

namespace MedicalAppointment.Application.Contracts.system
{
    public interface IStatusService : IBaseService<StatusResponse, StatusSaveDto, StatusUpdateDto>
    {
    }
}
