

using MedicalAppointment.Application.Base;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.Extensions.Logging;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Application.Response.system.Status;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Application.Contracts.system;

namespace MedicalAppointment.Application.Services.System
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<StatusService> _logger;
        private readonly IStatusService _statusService;
        
        public StatusService(IStatusRepository statusRepository, ILogger<StatusService> logger)
        {
            if (statusRepository is null)
            {
                throw new ArgumentNullException(nameof(statusRepository));
            }

            _statusRepository = statusRepository;
            _logger = logger;

        }
        public async Task<StatusResponse> GetAll()
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var result = await _statusRepository.GetAll();

                if (!result.Success)
                {
                    statusResponse.Messages = result.Message;
                    statusResponse.IsSuccess = result.Success;

                    return statusResponse;
                }

                statusResponse.Data = result.Data;
            }
            catch (Exception ex)
            {
                statusResponse.IsSuccess = false;
                statusResponse.Messages = "Error obteniendo los status";
                _logger.LogError(statusResponse.Messages, ex.ToString());
            }

            return statusResponse;
        }

        public async Task<StatusResponse> GetById(int id)
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var result = await _statusRepository.GetEntityBy(id);

                Status status = (Status)result.Data;

                StatusGetDto statusGetDto = new StatusGetDto()
                {
                    StatusID = status.StatusID,
                    StatusName = status.StatusName
                };
                statusResponse.IsSuccess = result.Success;
                statusResponse.Data = statusGetDto;

            }
            catch (Exception ex)
            {

                statusResponse.IsSuccess = false;
                statusResponse.Messages = "Error obteniendo el StatusID";
                _logger.LogError(statusResponse.Messages, ex.ToString());
            }

            return statusResponse;
        }

        public async Task<StatusResponse> SaveAsync(StatusSaveDto dto)
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                Status status = new Status();
                status.StatusName = dto.StatusName;

                var result = await _statusRepository.Save(status);

            }
            catch (Exception ex)
            {
                statusResponse.IsSuccess = false;
                statusResponse.Messages = "Error guardando el Status";
                _logger.LogError (statusResponse.Messages, ex.ToString());
            }

            return statusResponse;
        }

        public async Task<StatusResponse> UpdateAsync(StatusUpdateDto dto)
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var resultGetById = await _statusRepository.GetEntityBy(dto.StatusID);

                if (!resultGetById.Success) 
                {
                    statusResponse.IsSuccess = resultGetById.Success;
                    statusResponse.Messages = resultGetById.Message;

                    return statusResponse;
                }

                Status status = new Status();
                
                status.StatusID = dto.StatusID;
                status.StatusName = dto.StatusName;

                var result = await _statusRepository.Update(status);

            }
            catch (Exception ex)
            {

                statusResponse.IsSuccess = false;
                statusResponse.Messages = "Error actualizando el Status";
                _logger.LogError(statusResponse.Messages, ex.ToString());

            }
            return statusResponse;
        }
    }
}
