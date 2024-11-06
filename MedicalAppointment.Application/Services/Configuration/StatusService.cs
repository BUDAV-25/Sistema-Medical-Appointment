

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.Configuration.Status;
using MedicalAppointment.Application.Response.Configuration.Status;
using MedicalAppointment.Persistance.Interfaces.system;
using Microsoft.Extensions.Logging;
using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Application.Contracts;

namespace MedicalAppointment.Application.Services.Configuration
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger _logger;
        public StatusService(IStatusRepository statusRepository, ILogger<StatusService> logger)
        {
            if (statusRepository is null)
            {
                throw new ArgumentNullException(nameof(statusRepository));
            }

            this._statusRepository = statusRepository;
            this._logger = logger;
        }
        public async Task<StatusResponse> GetAll()
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var result = await _statusRepository.GetAll();

                List<StatusGetDto> statuses = ((List<Status>)result.Data).Select(statuses => new StatusGetDto()
                {
                    StatusID = statuses.StatusID,
                    StatusName = statuses.StatusName

                }).ToList();



                statusResponse.IsSuccess = result.Success;
                statusResponse.Model = statuses;
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
                statusResponse.Model = statusGetDto;

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
                status.StatusID = dto.StatusID;
                status.StatusName = dto.StatusName;

                var result = await _statusRepository.Save(status);
                statusResponse.IsSuccess = false;
                statusResponse.Messages = "Error guardando el Status";
                

            }
            catch (Exception)
            {

                throw;
            }

            return statusResponse;
        }

        public async Task<StatusResponse> UpdateAsync(StatusUpdateDto dto)
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var resultEntity = await _statusRepository.GetEntityBy(dto.StatusID);

                Status statusToUpdate = (Status)resultEntity.Data;

                statusToUpdate.StatusID = dto.StatusID;
                statusToUpdate.StatusName = dto.StatusName;

                var result = await _statusRepository.Update(statusToUpdate);

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
