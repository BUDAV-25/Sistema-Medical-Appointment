

using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Consumption.Base;
using MedicalAppointment.Consumption.IClientService.system;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;
using MedicalAppointment.Consumption.ModelsMethods.system.Status;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Consumption.ServicesConsumption.system
{
    public class StatusServiceConsumption : IStatusClientService
    {
        private readonly IBaseConsumption _baseConsumption;
        private readonly ILogger<StatusServiceConsumption> _logger;
        private readonly IConfiguration _configuration;

        public StatusServiceConsumption(IBaseConsumption baseConsumption, ILogger<StatusServiceConsumption> logger)
        {
            _baseConsumption = baseConsumption;
            _logger = logger;
        }

        public async Task<StatusGetAllModel> GetStatus()
        {
            StatusGetAllModel statusGetAll = new StatusGetAllModel();

            try
            {
                statusGetAll = await _baseConsumption.GetAllConsumption<StatusGetAllModel>("Status/GetAllStatus");
            }
            catch (Exception ex)
            {
                statusGetAll.isOkay = false;
                statusGetAll.mensaje = "Error obteniendo las notificaciones";
                _logger.LogError($"{statusGetAll.mensaje} {ex.ToString()}");
            }
            return statusGetAll;
        }

        public async Task<StatusGetByIdModel> GetStatusById()
        {
            StatusGetByIdModel statusGetById = new StatusGetByIdModel();

            try
            {
                statusGetById = await _baseConsumption.GetByIdConsumption<StatusGetByIdModel>("Status/GetStatusBy");
            }
            catch (Exception ex)
            {
                statusGetById.isOkay = false;
                statusGetById.mensaje = "Error obteniendo los detalles.";
                _logger.LogError($"{statusGetById.mensaje} {ex.ToString()}");

            }
            return statusGetById;
        }

        public Task<StatusSaveDto> SaveStatus(StatusSaveDto statusSaveDto)
        {
            throw new NotImplementedException();
        }

        public Task<StatusUpdateDto> UpdateStatus(StatusUpdateDto statusUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
