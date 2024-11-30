using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Web.ModelsMethods.users.PatientTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.users
{
    public interface IPatientContract : Interfaces<PatientGetAllModel, PatientGetByIdModel, PatientSaveDto, PatientUpdateDto>
    {
    }
}
