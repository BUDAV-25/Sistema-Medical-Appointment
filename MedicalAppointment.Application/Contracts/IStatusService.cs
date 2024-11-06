

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.Configuration.Status;
using MedicalAppointment.Application.Response.Configuration.Status;

namespace MedicalAppointment.Application.Contracts
{
    public interface IStatusService : IBaseService<StatusResponse, StatusSaveDto, StatusUpdateDto>
    {
    }
}
