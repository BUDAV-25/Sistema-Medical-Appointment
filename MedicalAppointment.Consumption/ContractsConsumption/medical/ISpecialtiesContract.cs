using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Consumption.Client;
using MedicalAppointment.Consumption.ModelsMethods.medical.SpecialtiesTaskModel;

namespace MedicalAppointment.Consumption.ContractsConsumption.medical
{
    public interface ISpecialtiesContract : Interfaces<SpecialtiesGetAllModel, SpecialtiesGetByIdModel, 
        SpecialtiesSaveDto, SpecialtiesUpdateDto>
    {
    }
}
