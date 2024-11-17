using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Application.Response.medical.AvailabilityModes;

namespace MedicalAppointment.Application.Contracts.medical
{
    public interface IAvailabilityModesService : IBaseService<AvailabilityModesResponse,
        AvailabilityModesSaveDto, AvailabilityModesUpdateDto>
    {
    }
}
