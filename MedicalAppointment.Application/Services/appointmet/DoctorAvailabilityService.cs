using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts.appointments;
using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Application.Response.appointments.DoctorAvailability;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.appointmet
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly ILogger<DoctorAvailabilityService> _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository, ILogger<DoctorAvailabilityService> logger)
        {
            if (doctorAvailabilityRepository is null)
            {
                throw new ArgumentNullException(nameof(doctorAvailabilityRepository));
            }

            _doctorAvailabilityRepository = doctorAvailabilityRepository;
            _logger = logger;

        }
        public async Task<DoctorAvailabilityResponse> GetAll()
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var result = await _doctorAvailabilityRepository.GetAll();

                List<DoctorAvailabilityGetDto> doctorAvailabilities = ((List<DoctorAvailability>)result.Data).Select(doctorAvailabilities => new DoctorAvailabilityGetDto()
                {
                    AvailabilityID = doctorAvailabilities.AvailabilityID,
                    DoctorID = doctorAvailabilities.DoctorID,
                    AvailableDate = doctorAvailabilities.AvailableDate,
                    StarTime = doctorAvailabilities.StartTime,
                    EndTime = doctorAvailabilities.EndTime

                }).ToList();

                doctorAvailabilityResponse.IsSuccess = result.Success;
                doctorAvailabilityResponse.Data = doctorAvailabilities;
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Messages = "Error obteniendo las disponibilidades";
                _logger.LogError(doctorAvailabilityResponse.Messages, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> GetById(int id)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var result = await _doctorAvailabilityRepository.GetEntityBy(id);

                DoctorAvailability doctorAvailability = (DoctorAvailability)result.Data;
                DoctorAvailabilityGetDto doctorAvailabilityGetDto = new DoctorAvailabilityGetDto()
                {
                    AvailabilityID = doctorAvailability.AvailabilityID,
                    DoctorID = doctorAvailability.DoctorID,
                    AvailableDate = doctorAvailability.AvailableDate,
                    StarTime = doctorAvailability.StartTime,
                    EndTime = doctorAvailability.EndTime,
                };

                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Data = doctorAvailabilityGetDto;

            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Messages = "Error obteniendo la disponibilidad del doctor por su ID";
                _logger.LogError(doctorAvailabilityResponse.Messages, ex.ToString());
            }
            return doctorAvailabilityResponse;

        }

        public async Task<DoctorAvailabilityResponse> SaveAsync(DoctorAvailabilitySaveDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                DoctorAvailability doctorAvailability = new DoctorAvailability();
                doctorAvailability.DoctorID = dto.DoctorID;
                doctorAvailability.AvailableDate = dto.AvailableDate;
                doctorAvailability.StartTime = dto.StarTime;
                doctorAvailability.EndTime = dto.EndTime;

                var result = await _doctorAvailabilityRepository.Save(doctorAvailability);

            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Messages = "Error guardando la disponibilidad del doctor";
                _logger.LogError(doctorAvailabilityResponse.Messages, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> UpdateAsync(DoctorAvailabilityUpdateDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var resultEntity = await _doctorAvailabilityRepository.GetEntityBy(dto.AvailabilityID);

                DoctorAvailability doctorAvailabilityToUpdate = (DoctorAvailability)resultEntity.Data;

                doctorAvailabilityToUpdate.DoctorID = dto.DoctorID;
                doctorAvailabilityToUpdate.AvailableDate = dto.AvailableDate;
                doctorAvailabilityToUpdate.StartTime = dto.StarTime;
                doctorAvailabilityToUpdate.EndTime = dto.EndTime;

                var result = await _doctorAvailabilityRepository.Update(doctorAvailabilityToUpdate);
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Messages = "Error actualizando la disponibilidad del doctor";
                _logger.LogError(doctorAvailabilityResponse.Messages, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }
    }
}
