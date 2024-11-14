using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Application.Response.users.Patient;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.users
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patient_Repository;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IPatientRepository patientRepository,
                            ILogger<PatientService> logger)
        {
            if (patientRepository == null)
            {
                throw new ArgumentNullException(nameof(patientRepository));
            }
            patient_Repository = patientRepository;
            _logger = logger;
        }
        public async Task<PatientResponse> GetAll()
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                var result = await patient_Repository.GetAll();

                List<GetPatientDto> patients = ((List<Patient>)result.Data).Select(patient => new GetPatientDto()
                                                  {
                                                    DateOfBirth = patient.DateOfBirth,
                                                    Gender = patient.Gender,
                                                    PhoneNumber = patient.PhoneNumber,
                                                    Address = patient.Address,
                                                    EmergencyContactName = patient.EmergencyContactName,
                                                    EmergencyContactPhone = patient.EmergencyContactPhone,
                                                    BloodType = patient.BloodType,
                                                    Allergies = patient.Allergies,
                                                    InsuranceProviderID = patient.InsuranceProviderID
                                                  }).ToList();
                patientResponse.IsSuccess = true;
                patientResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                patientResponse.IsSuccess = false;
                patientResponse.Messages = "Error obteniendo los pacientes";
                _logger.LogError(patientResponse.Messages, ex.ToString());
            }
            return patientResponse;
        }
        public async Task<PatientResponse> GetById(int id)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                var result = await patient_Repository.GetEntityBy(id);
                Patient patient = (Patient)result.Data;
                GetPatientDto patientDto = new GetPatientDto()
                {
                    DateOfBirth = patient.DateOfBirth,
                    Gender = patient.Gender,
                    PhoneNumber = patient.PhoneNumber,
                    Address = patient.Address,
                    EmergencyContactName = patient.EmergencyContactName,
                    EmergencyContactPhone = patient.EmergencyContactPhone,
                    BloodType = patient.BloodType,
                    Allergies = patient.Allergies,
                    InsuranceProviderID = patient.InsuranceProviderID
                };
                patientResponse.IsSuccess = true;
                patientResponse.Model = patientDto;
            }
            catch (Exception ex)
            {
                patientResponse.IsSuccess = false;
                patientResponse.Messages = "Error obteniendo el paciente";
                _logger.LogError(patientResponse.Messages, ex.ToString());
            }
            return patientResponse;
        }
        public async Task<PatientResponse> SaveAsync(PatientSaveDto dto)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                Patient patient = new Patient();
                patient.DateOfBirth = dto.DateOfBirth;
                patient.Gender = dto.Gender;
                patient.PhoneNumber = dto.PhoneNumber;
                patient.Address = dto.Address;
                patient.EmergencyContactName = dto.EmergencyContactName;
                patient.EmergencyContactPhone = dto.EmergencyContactPhone;
                patient.BloodType = dto.BloodType;
                patient.Allergies = dto.Allergies;
                patient.InsuranceProviderID = dto.InsuranceProviderID;
                patient.CreatedAt = dto.CreatedAt;

                var result = await patient_Repository.Save(patient);
            }
            catch (Exception ex)
            {
                patientResponse.IsSuccess = false;
                patientResponse.Messages = "Error guardando el paciente";
                _logger.LogError(patientResponse.Messages, ex.ToString());
            }
            return patientResponse;
        }
        public async Task<PatientResponse> UpdateAsync(PatientUpdateDto dto)
        {
            PatientResponse patientResponse = new PatientResponse();
            try
            {
                var resultEntity = await patient_Repository.GetEntityBy(dto.PatientID);
                Patient patientToUpdate = (Patient)resultEntity.Data;

                patientToUpdate.DateOfBirth = dto.DateOfBirth;
                patientToUpdate.Gender = dto.Gender;
                patientToUpdate.PhoneNumber = dto.PhoneNumber;
                patientToUpdate.Address = dto.Address;
                patientToUpdate.EmergencyContactName = dto.EmergencyContactName;
                patientToUpdate.EmergencyContactPhone = dto.EmergencyContactPhone;
                patientToUpdate.BloodType = dto.BloodType;
                patientToUpdate.Allergies = dto.Allergies;
                patientToUpdate.InsuranceProviderID = dto.InsuranceProviderID;
                patientToUpdate.UpdatedAt = dto.UpdatedAt;
                patientToUpdate.IsActive = dto.IsActive;

                var result = await patient_Repository.Update(patientToUpdate);
            }
            catch (Exception ex)
            {
                patientResponse.IsSuccess = false;
                patientResponse.Messages = "Error actualizando el paciente";
                _logger.LogError(patientResponse.Messages, ex.ToString());
            }
            return patientResponse;
        }
    }
}
