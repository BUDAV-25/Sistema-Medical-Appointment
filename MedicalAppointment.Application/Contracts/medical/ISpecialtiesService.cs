using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Application.Response.medical.Specialties;

namespace MedicalAppointment.Application.Contracts.medical
{
    public interface ISpecialtiesService : IBaseService<SpecialtiesResponse,
        SpecialtiesSaveDto,SpecialtiesUpdateDto>
    {
    }
}
