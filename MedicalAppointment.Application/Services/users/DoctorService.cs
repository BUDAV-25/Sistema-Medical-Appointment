using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Application.Response.users.Doctor;
using MedicalAppointment.Application.Response.users.User;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.users
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctor_Repository;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IDoctorRepository doctorRepository,
                            ILogger<DoctorService> logger)
        {
            if (doctorRepository == null)
            {
                throw new ArgumentNullException(nameof(doctorRepository));
            }
            doctor_Repository = doctorRepository;
            _logger = logger;
        }
        public async Task<DoctorResponse> GetAll()
        {
            DoctorResponse doctorResponse = new DoctorResponse();
            try
            {
                var result = await doctor_Repository.GetAll();

                if (!result.Success)
                {
                    doctorResponse.IsSuccess = result.Success;
                    doctorResponse.Messages = result.Message;
                    return doctorResponse;
                }
                doctorResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                doctorResponse.IsSuccess = false;
                doctorResponse.Messages = "Error obteniendo los doctores";
                _logger.LogError(doctorResponse.Messages, ex.ToString());
            }
            return doctorResponse;
        }
        public async Task<DoctorResponse> GetById(int id)
        {
            DoctorResponse doctorResponse = new DoctorResponse();
            try
            {
                var result = await doctor_Repository.GetEntityBy(id);
                if (!result.Success)
                {
                    doctorResponse.IsSuccess = result.Success;
                    doctorResponse.Messages = result.Message;
                    return doctorResponse;
                }
                doctorResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                doctorResponse.IsSuccess = false;
                doctorResponse.Messages = "Error obteniendo al doctor";
                _logger.LogError(doctorResponse.Messages, ex.ToString());
            }
            return doctorResponse;
        }
        public async Task<DoctorResponse> SaveAsync(DoctorSaveDto dto)
        {
            DoctorResponse doctorResponse= new DoctorResponse();
            try
            {
                Doctor doctor = new Doctor();

                doctor.DoctorID = dto.DoctorID;
                doctor.SpecialtyID = dto.SpecialtyID;
                doctor.LicenseNumber = dto.LicenseNumber;
                doctor.PhoneNumber = dto.PhoneNumber;
                doctor.YearsOfExperience = dto.YearsOfExperience;
                doctor.Education = dto.Education;
                doctor.Bio = dto.Bio;
                doctor.ConsultationFee = dto.ConsultationFee;
                doctor.ClinicAddress = dto.ClinicAddress;
                doctor.AvailabilityModeId = dto.AvailabilityModeId;
                doctor.LicenseExpirationDate = dto.LicenseExpirationDate;
                doctor.CreatedAt = dto.CreatedAt;
                doctor.IsActive = true;

                var result = await doctor_Repository.Save(doctor);
            }
            catch (Exception ex)
            {
                doctorResponse.IsSuccess = false;
                doctorResponse.Messages = "Error guardando el doctor";
                _logger.LogError(doctorResponse.Messages, ex.ToString());
            }
            return doctorResponse;
        }
        public async Task<DoctorResponse> UpdateAsync(DoctorUpdateDto dto)
        {
            DoctorResponse doctorResponse = new DoctorResponse();
            try
            {
                var resultEntity = await doctor_Repository.GetEntityBy(dto.DoctorID);
                if (!resultEntity.Success)
                {
                    doctorResponse.IsSuccess = resultEntity.Success;
                    doctorResponse.Messages = resultEntity.Message;
                }
                Doctor doctorUpdate = new Doctor();

                doctorUpdate.DoctorID = dto.DoctorID;
                doctorUpdate.SpecialtyID = dto.SpecialtyID;
                doctorUpdate.LicenseNumber = dto.LicenseNumber;
                doctorUpdate.PhoneNumber = dto.PhoneNumber;
                doctorUpdate.YearsOfExperience = dto.YearsOfExperience;
                doctorUpdate.Education = dto.Education;
                doctorUpdate.Bio = dto.Bio;
                doctorUpdate.ConsultationFee = dto.ConsultationFee;
                doctorUpdate.ClinicAddress = dto.ClinicAddress;
                doctorUpdate.AvailabilityModeId = dto.AvailabilityModeId;
                doctorUpdate.LicenseExpirationDate = dto.LicenseExpirationDate;
                doctorUpdate.UpdatedAt = dto.UpdatedAt;
                doctorUpdate.IsActive = dto.IsActive;

                var result = await doctor_Repository.Update(doctorUpdate);

            }
            catch (Exception ex)
            {
                doctorResponse.IsSuccess = false;
                doctorResponse.Messages = "Error actualizando el doctor";
                _logger.LogError(doctorResponse.Messages, ex.ToString());
            }
            return doctorResponse;
        }
    }
}
