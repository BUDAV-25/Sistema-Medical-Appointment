using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Application.Response.medical.AvailabilityModes;
using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.medical
{
    public class AvailabilityModesService : IAvailabilityModesService
    {
        private readonly IAvailabilityModesRepository availability_ModesRepository;
        private readonly ILogger<AvailabilityModesService> _logger;

        public AvailabilityModesService(IAvailabilityModesRepository availabilityModesRepository,
                                        ILogger<AvailabilityModesService> logger)
        {
            if (availabilityModesRepository == null)
            {
                throw new ArgumentNullException(nameof(availabilityModesRepository));
            }
            availability_ModesRepository = availabilityModesRepository;
            _logger = logger;
        }
        public async Task<AvailabilityModesResponse> GetAll()
        {
            AvailabilityModesResponse availabilityModesResponse = new AvailabilityModesResponse();
            try
            {
                var result = await availability_ModesRepository.GetAll();

                if (!result.Success)
                {
                    availabilityModesResponse.IsSuccess = result.Success;
                    availabilityModesResponse.Messages = result.Message;
                    return availabilityModesResponse;
                }
                availabilityModesResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                availabilityModesResponse.IsSuccess = false;
                availabilityModesResponse.Messages = "Error obteniendo los modos";
                _logger.LogError(availabilityModesResponse.Messages, ex.ToString());
            }
            return availabilityModesResponse;
        }
        public async Task<AvailabilityModesResponse> GetById(int id)
        {
            AvailabilityModesResponse availabilityModesResponse = new AvailabilityModesResponse();
            try
            {
                var result = await availability_ModesRepository.GetEntityBy(id);

                if (!result.Success)
                {
                    availabilityModesResponse.IsSuccess = result.Success;
                    availabilityModesResponse.Messages = result.Message;
                    return availabilityModesResponse;
                }
                availabilityModesResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                availabilityModesResponse.IsSuccess = false;
                availabilityModesResponse.Messages = "Error obteniendo el modo";
                _logger.LogError(availabilityModesResponse.Messages, ex.ToString());
            }
            return availabilityModesResponse;
        }
        public async Task<AvailabilityModesResponse> SaveAsync(AvailabilityModesSaveDto dto)
        {
            AvailabilityModesResponse availabilityModesResponse = new AvailabilityModesResponse();
            try
            {
                AvailabilityModes availability = new AvailabilityModes();

                //availability.SAvailabilityModeID = dto.SAvailabilityModeID;
                availability.AvailabilityMode = dto.AvailabilityMode;
                availability.CreatedAt = dto.CreatedAt;
                availability.IsActive = true;

                var result = await availability_ModesRepository.Save(availability);
            }
            catch (Exception ex)
            {
                availabilityModesResponse.IsSuccess = false;
                availabilityModesResponse.Messages = "Error guardando el modo";
                _logger.LogError(availabilityModesResponse.Messages, ex.ToString());
            }
            return availabilityModesResponse;
        }
        public async Task<AvailabilityModesResponse> UpdateAsync(AvailabilityModesUpdateDto dto)
        {
            AvailabilityModesResponse availabilityModesResponse = new AvailabilityModesResponse();
            try
            {
                var resultEntity = await availability_ModesRepository.GetEntityBy(dto.SAvailabilityModeID);

                if (!resultEntity.Success)
                {
                    availabilityModesResponse.IsSuccess = resultEntity.Success;
                    availabilityModesResponse.Messages = resultEntity.Message;
                    return availabilityModesResponse;
                }

                AvailabilityModes availability = new AvailabilityModes();

                availability.SAvailabilityModeID = dto.SAvailabilityModeID;
                availability.AvailabilityMode = dto.AvailabilityMode;
                availability.UpdatedAt = dto.UpdatedAt;
                availability.IsActive = dto.IsActive;

                var result = await availability_ModesRepository.Update(availability);
            }
            catch (Exception ex)
            {
                availabilityModesResponse.IsSuccess = false;
                availabilityModesResponse.Messages = "Error actualizando el modo";
                _logger.LogError(availabilityModesResponse.Messages, ex.ToString());
            }
            return availabilityModesResponse;
        }
    }
}