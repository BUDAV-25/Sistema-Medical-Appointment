﻿using MedicalAppointment.Application.Contracts.medical;
using MedicalAppointment.Application.Dtos.medical.MedicalRecords;
using MedicalAppointment.Application.Response.medical.MedicalRecords;
using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Persistance.Interfaces.medical;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.medical
{
    public class MedicalRecordsService : IMedicalRecordsService
    {
        private readonly IMedicalRecordsRepository medicalRecords_Repository;
        private readonly ILogger<MedicalRecordsService> _logger;

        public MedicalRecordsService(IMedicalRecordsRepository medicalRecordsRespository,
                                    ILogger<MedicalRecordsService> logger)
        {
            if (medicalRecordsRespository == null)
            {
                throw new ArgumentNullException(nameof(medicalRecordsRespository));
            }
            medicalRecords_Repository = medicalRecordsRespository;
            _logger = logger;
        }
        public async Task<MedicalRecordsResponse> GetAll()
        {
            MedicalRecordsResponse recordResponse = new MedicalRecordsResponse();
            try
            {
                var result = await medicalRecords_Repository.GetAll();

                if (!result.Success)
                {
                    recordResponse.IsSuccess = result.Success;
                    recordResponse.Messages = result.Message;
                    return recordResponse;
                }
                recordResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                recordResponse.IsSuccess = false;
                recordResponse.Messages = "Error al obtener los records";
                _logger.LogError(recordResponse.Messages, ex.ToString());
            }
            return recordResponse;
        }
        public async Task<MedicalRecordsResponse> GetById(int id)
        {
            MedicalRecordsResponse recordResponse = new MedicalRecordsResponse();
            try
            {
                var result = await medicalRecords_Repository.GetEntityBy(id);
                
                if (!result.Success)
                {
                    recordResponse.IsSuccess = result.Success;
                    recordResponse.Messages = result.Message;
                    return recordResponse;
                }
                recordResponse.Model = result.Data;
            }
            catch (Exception ex)
            {
                recordResponse.IsSuccess = false;
                recordResponse.Messages = "Error al obtener el record";
                _logger.LogError(recordResponse.Messages, ex.ToString());
            }
            return recordResponse;
        }
        public async Task<MedicalRecordsResponse> SaveAsync(MedicalRecordsSaveDto dto)
        {
            MedicalRecordsResponse recordResponse = new MedicalRecordsResponse();
            try
            {
                MedicalRecords record = new MedicalRecords();
                record.PatientID = dto.PatientID;
                record.DoctorID = dto.DoctorID;
                record.Diagnosis = dto.Diagnosis;
                record.Treatment = dto.Treatment;
                record.DateOfVisit = dto.DateOfVisit;
                record.CreatedAt = dto.CreatedAt;

                var result = await medicalRecords_Repository.Save(record);
            }
            catch (Exception ex)
            {
                recordResponse.IsSuccess = false;
                recordResponse.Messages = "Error al guardar el record";
                _logger.LogError(recordResponse.Messages, ex.ToString());
            }
            return recordResponse;
        }
        public async Task<MedicalRecordsResponse> UpdateAsync(MedicalRecordsUpdateDto dto)
        {
            MedicalRecordsResponse recordResponse = new MedicalRecordsResponse();
            try
            {
                var resultEntity = await medicalRecords_Repository.GetEntityBy(dto.RecordID);

                if (!resultEntity.Success)
                {
                    recordResponse.IsSuccess = resultEntity.Success;
                    recordResponse.Messages = resultEntity.Message;
                    return recordResponse;
                }

                MedicalRecords recordToUpdate = new MedicalRecords();

                recordToUpdate.PatientID = dto.PatientID;
                recordToUpdate.DoctorID = dto.DoctorID;
                recordToUpdate.Diagnosis = dto.Diagnosis;
                recordToUpdate.Treatment = dto.Treatment;
                recordToUpdate.DateOfVisit = dto.DateOfVisit;
                recordToUpdate.UpdatedAt = dto.UpdatedAt;

                var result = await medicalRecords_Repository.Update(recordToUpdate);
            }
            catch (Exception ex)
            {
                recordResponse.IsSuccess = false;
                recordResponse.Messages = "Error al actualizar el record";
                _logger.LogError(recordResponse.Messages, ex.ToString());
            }
            return recordResponse;
        }
    }
}
