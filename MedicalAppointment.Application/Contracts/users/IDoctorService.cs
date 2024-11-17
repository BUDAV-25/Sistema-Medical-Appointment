using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Application.Response.users.Doctor;

namespace MedicalAppointment.Application.Contracts.users
{
    public interface IDoctorService : IBaseService<DoctorResponse,DoctorSaveDto,DoctorUpdateDto>
    {
    }
}
