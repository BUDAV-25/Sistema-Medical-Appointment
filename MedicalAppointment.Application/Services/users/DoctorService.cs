﻿using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Application.Response.users.Doctor;
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

                List<GetDoctorDto> doctors = ((List<Doctor>)result.Data).Select(doctor => new GetDoctorDto()
                                                {
                                                 SpecialtyID = doctor.SpecialtyID,
                                                 PhoneNumber = doctor.PhoneNumber,
                                                 ConsultationFee = doctor.ConsultationFee,
                                                 ClinicAddress = doctor.ClinicAddress,
                                                 AvailabilityModeId = doctor.AvailabilityModeId
                                                }).ToList();
                doctorResponse.IsSuccess = true;
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
                Doctor doctor = (Doctor)result.Data;
                GetDoctorDto doctorDto = new GetDoctorDto()
                {
                    SpecialtyID = doctor.SpecialtyID,
                    PhoneNumber = doctor.PhoneNumber,
                    ConsultationFee = doctor.ConsultationFee,
                    ClinicAddress = doctor.ClinicAddress,
                    AvailabilityModeId = doctor.AvailabilityModeId
                };
                doctorResponse.IsSuccess= true;
                doctorResponse.Model = doctorDto;
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
                Doctor doctorUpdate = (Doctor)resultEntity.Data;

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
