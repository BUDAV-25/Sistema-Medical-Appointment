using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.medical.MedicalRecordsTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.medical
{
    public interface IMedicalRecordsContract : Interfaces<MedicalRecordsGetAllModel, MedicalRecordsGetByIdModel,
        MedicalRecordsSaveDto, MedicalRecordsUpdateDto>
    {
    }
}
