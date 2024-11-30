using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ModelsMethods.medical.AvailabilityModeTaskModel;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.medical
{
    public class AvailabilityModesServiceConsumption : IAvailabilityModesContract
    {
        private readonly IBaseConsumption base_Consumption;
        private readonly ILogger<AvailabilityModesServiceConsumption> _logger;
        public AvailabilityModesServiceConsumption(IBaseConsumption baseConsumption, ILogger<AvailabilityModesServiceConsumption> logger)
        {
            base_Consumption = baseConsumption;
            _logger = logger;
        }
        public async Task<AvailabilityModeGetAllModel> GetAll()
        {
            AvailabilityModeGetAllModel availabilityModeGetAllModel = new AvailabilityModeGetAllModel();
            try
            {
                availabilityModeGetAllModel = await base_Consumption.GetAllConsumption<AvailabilityModeGetAllModel>("AvailabilityModes/GetAllAvailabilityModes");
            }
            catch (Exception ex)
            {
                availabilityModeGetAllModel.isOkay = false;
                availabilityModeGetAllModel.mensaje = "Error obteniendo los modos";
                _logger.LogError(availabilityModeGetAllModel.mensaje, ex.ToString());
            }
            return availabilityModeGetAllModel;
        }
        public async Task<AvailabilityModesGetByIdModel> GetById(int id)
        {
            AvailabilityModesGetByIdModel availabilityModesGetByIdModel = new AvailabilityModesGetByIdModel();
            try
            {
                availabilityModesGetByIdModel = await base_Consumption.GetByIdConsumption<AvailabilityModesGetByIdModel>($"AvailabilityModes/GetAvailabilityby{id}");
            }
            catch (Exception ex)
            {
                availabilityModesGetByIdModel.isOkay = false;
                availabilityModesGetByIdModel.mensaje = "Error obteniendo el modo";
                _logger.LogError(availabilityModesGetByIdModel.mensaje, ex.ToString());
            }
            return availabilityModesGetByIdModel;
        }
        public async Task<AvailabilityModesSaveDto> Save(AvailabilityModesSaveDto availabilitySave)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                availabilitySave.CreatedAt = DateTime.Now;
                var result = await base_Consumption.SaveConsumption<AvailabilityModesSaveDto>("AvailabilityModes/SaveAvailability", availabilitySave);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error guardando el modo";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return availabilitySave;
        }
        public async Task<AvailabilityModesUpdateDto> Update(AvailabilityModesUpdateDto availabilityUpdate)
        {
            BaseResponseConsumption model = new BaseResponseConsumption();
            try
            {
                availabilityUpdate.UpdatedAt = DateTime.Now;
                var result = await base_Consumption.UpdateConsumption<AvailabilityModesUpdateDto>("AvailabilityModes/UpdateAvailability", availabilityUpdate);
            }
            catch (Exception ex)
            {
                model.isOkay = false;
                model.mensaje = "Error actualizando el modo";
                _logger.LogError(model.mensaje, ex.ToString());
            }
            return availabilityUpdate;
        }
    }
}
