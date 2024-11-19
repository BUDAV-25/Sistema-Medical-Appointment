using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Application.Response.medical.MedicalRecords;

namespace MedicalAppointment.Application.Contracts.medical
{
    public interface IMedicalRecordsService : IBaseService<MedicalRecordsResponse,
        MedicalRecordsSaveDto,MedicalRecordsUpdateDto>
    {
    }
}
