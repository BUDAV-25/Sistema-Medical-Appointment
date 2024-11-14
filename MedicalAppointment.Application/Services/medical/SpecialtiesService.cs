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
                List<GetSpecialtiesDto> getSpecialties = ((List<Specialties>)result.Data)
                                                .Select(specialties => new GetSpecialtiesDto()
                                                {
                                                    SpecialtyID = specialties.SpecialtyID,
                                                    SpecialtyName = specialties.SpecialtyName
                                                }).ToList();
                specialtiesResponse.IsSuccess = true;
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
                Specialties specialties = (Specialties)result.Data;
                GetSpecialtiesDto special = new GetSpecialtiesDto()
                {
                    SpecialtyID = specialties.SpecialtyID,
                    SpecialtyName = specialties.SpecialtyName
                };
                specialtiesResponse.IsSuccess= true;
                specialtiesResponse.Model = result.Data;
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
                Specialties specialtiesToUpdate = (Specialties)resultEntity.Data;

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
