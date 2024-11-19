using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Application.Response.users.Patient;

namespace MedicalAppointment.Application.Contracts.users
{
    public interface IPatientService : IBaseService<PatientResponse,PatientSaveDto,PatientUpdateDto>
    {
    }
}
