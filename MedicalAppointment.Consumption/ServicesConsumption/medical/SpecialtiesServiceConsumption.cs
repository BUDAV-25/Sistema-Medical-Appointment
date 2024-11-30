using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ModelsMethods.medical.SpecialtiesTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.medical
{
    public class SpecialtiesServiceConsumption : ISpecialtiesContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<SpecialtiesServiceConsumption> _logger;
        public SpecialtiesServiceConsumption(IBaseConsumption baseConsumption, ILogger<SpecialtiesServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<SpecialtiesGetAllModel> GetAll()
        {
            SpecialtiesGetAllModel model = new SpecialtiesGetAllModel();
            try
            {
                model = await base_Consumption.GetAllConsumption<SpecialtiesGetAllModel>("Specialties/GetAllSpecialties");
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error obteniendo las especialidades";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return model;
        }
        public async Task<SpecialtiesGetByIdModel> GetById(int id)
        {
            SpecialtiesGetByIdModel model = new SpecialtiesGetByIdModel();
            try
            {
                model = await base_Consumption.GetByIdConsumption<SpecialtiesGetByIdModel>($"Specialties/GetSpecialtyby{id}");
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error obteniendo la especialidad";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return model;
        }
        public async Task<SpecialtiesSaveDto> Save(SpecialtiesSaveDto specialtiesSave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                specialtiesSave.CreatedAt = DateTime.Now;
                var result = await base_Consumption.SaveConsumption<SpecialtiesSaveDto>("Specialties/SaveSpecialty", specialtiesSave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando la especialidad";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return specialtiesSave;
        }
        public async Task<SpecialtiesUpdateDto> Update(SpecialtiesUpdateDto specialtiesUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                specialtiesUpdate.UpdatedAt = DateTime.Now;
                var result = await base_Consumption.UpdateConsumption<SpecialtiesUpdateDto>("Specialties/UpdateSpecialtyby", specialtiesUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando la especialidad";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return specialtiesUpdate;
        }
    }
}
