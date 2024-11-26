using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.ContractsConsumption.system;
using MedicalAppointment.Consumption.ModelsMethods.Core;
using MedicalAppointment.Consumption.ModelsMethods.system.Status;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class StatusServiceConsumption : IStatusContracts
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<StatusServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public StatusServiceConsumption(IBaseConsumption baseConsumption, ILogger<StatusServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<StatusGetAllModel> GetAll()
        {
            StatusGetAllModel statusGetAll = new StatusGetAllModel();

            try
            {
                statusGetAll = await _baseConsumption.GetAllConsumption<StatusGetAllModel>("Status/GetAllStatus");
            }
            catch (Exception ex)
            {
                statusGetAll.isOkay = false;
                statusGetAll.mensaje = "Error al obtener los status.";
                _logger.LogError($"{statusGetAll.mensaje} {ex.ToString()}");
            }
            return statusGetAll;
        }

        public async Task<StatusGetByIdModel> GetById(int id)
        {
            StatusGetByIdModel statusGetById = new StatusGetByIdModel();

            try
            {
                statusGetById = await _baseConsumption.GetByIdConsumption<StatusGetByIdModel>($"Status/GetStatusBy{id}");
            }
            catch (Exception ex)
            {
                statusGetById.isOkay = false;
                statusGetById.mensaje = "Error obteniendo el status.";
                _logger.LogError($"{statusGetById.mensaje} {ex.ToString()}");
            }
            return statusGetById;
        }

        public async Task<StatusSaveDto> Save(StatusSaveDto saveDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                var statusSave = await _baseConsumption.SaveConsumption<StatusSaveDto>("Status/SaveStatus", saveDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al guardar el status.";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return saveDto;
        }

        public async Task<StatusUpdateDto> Update(StatusUpdateDto updateDto)
        {
            BaseResponseConsumption baseResponse = new BaseResponseConsumption();

            try
            {
                var statusUpdate = await _baseConsumption.UpdateConsumption<StatusUpdateDto>($"Status/UpdateStatus{updateDto.StatusID}", updateDto);
            }
            catch (Exception ex)
            {
                baseResponse.isOkay = false;
                baseResponse.mensaje = "Error al actualizar el status";
                _logger.LogError($"{baseResponse.mensaje} {ex.ToString()}");
            }
            return updateDto;
        }
    }
}
