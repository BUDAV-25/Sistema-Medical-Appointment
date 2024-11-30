using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Application.Response.medical.Specialties;
using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.medical
{
    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly ISpecialtiesRepository specialties_Repository;
        private readonly ILogger<SpecialtiesService> _logger;

        public SpecialtiesService(ISpecialtiesRepository specialtiesRepository,
                                    ILogger<SpecialtiesService> logger)
        {
            if (specialtiesRepository == null)
            {
                throw new ArgumentNullException(nameof(specialtiesRepository));
            }
            specialties_Repository = specialtiesRepository;
            _logger = logger;
        }
        public async Task<SpecialtiesResponse> GetAll()
        {
            SpecialtiesResponse specialtiesResponse = new SpecialtiesResponse();
            try
            {
                var result = await specialties_Repository.GetAll();

                if (!result.Success)
                {
                    specialtiesResponse.IsSuccess = result.Success;
                    specialtiesResponse.Messages = result.Message;
                    return specialtiesResponse;
                }
                specialtiesResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                specialtiesResponse.IsSuccess = false;
                specialtiesResponse.Messages = "Error obteniendo las especialidades";
                _logger.LogError(specialtiesResponse.Messages, ex.ToString());
            }
            return specialtiesResponse;
        }
        public async Task<SpecialtiesResponse> GetById(int id)
        {
            SpecialtiesResponse specialtiesResponse= new SpecialtiesResponse();
            try
            {
                var result = await specialties_Repository.GetEntityBy(id);

                if (!result.Success)
                {
                    specialtiesResponse.IsSuccess = result.Success;
                    specialtiesResponse.Messages = result.Message;
                    return specialtiesResponse;
                }
                specialtiesResponse.Model= result.Data;
            }
            catch (Exception ex)
            {
                specialtiesResponse.IsSuccess = false;
                specialtiesResponse.Messages = "Error obteniendo la especialidad";
                _logger.LogError(specialtiesResponse.Messages, ex.ToString());
            }
            return specialtiesResponse;
        }
        public async Task<SpecialtiesResponse> SaveAsync(SpecialtiesSaveDto dto)
        {
            SpecialtiesResponse specialtiesResponse = new SpecialtiesResponse();
            try
            {
                Specialties specialties = new Specialties();
                specialties.SpecialtyName = dto.SpecialtyName;
                specialties.CreatedAt = dto.CreatedAt;
                specialties.UpdatedAt = dto.CreatedAt;
                specialties.IsActive = true;

                var result = await specialties_Repository.Save(specialties);
            }
            catch (Exception ex)
            {
                specialtiesResponse.IsSuccess = false;
                specialtiesResponse.Messages = "Error guardando la especialidad";
                _logger.LogError(specialtiesResponse.Messages, ex.ToString());
            }
            return specialtiesResponse;
        }
        public async Task<SpecialtiesResponse> UpdateAsync(SpecialtiesUpdateDto dto)
        {
            SpecialtiesResponse specialtiesResponse = new SpecialtiesResponse();
            try
            {
                var resultEntity = await specialties_Repository.GetEntityBy(dto.SpecialtyID);
                if (!resultEntity.Success)
                {
                    specialtiesResponse.IsSuccess = resultEntity.Success;
                    specialtiesResponse.Messages = resultEntity.Message;
                    return specialtiesResponse;
                }

                Specialties specialtiesToUpdate = new Specialties();

                specialtiesToUpdate.SpecialtyID = dto.SpecialtyID;
                specialtiesToUpdate.SpecialtyName = dto.SpecialtyName;
                specialtiesToUpdate.UpdatedAt = dto.UpdatedAt;
                specialtiesToUpdate.IsActive = dto.IsActive;

                var result = await specialties_Repository.Update(specialtiesToUpdate);
            }
            catch (Exception ex)
            {
                specialtiesResponse.IsSuccess = false;
                specialtiesResponse.Messages = "Error actualizando la especialidad";
                _logger.LogError(specialtiesResponse.Messages, ex.ToString());
            }
            return specialtiesResponse;
        }
    }
}
