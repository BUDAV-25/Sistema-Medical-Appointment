using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Web.Models.users.DoctorTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.users
{
    public interface IDoctorContract : Interfaces<DoctorGetAllModel, DoctorGetByIdModel, DoctorSaveDto, DoctorUpdateDto>
    {
    }
}
