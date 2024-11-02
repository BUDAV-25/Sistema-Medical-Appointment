﻿using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.users
{
    public sealed class PatientsRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<PatientsRepository> logger) : BaseRepository<Patients>(medicalAppointmentContext), IPatientsRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<PatientsRepository> logger = logger;
        public async override Task<OperationResult> Save(Patients entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if(entity.DateOfBirth == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha de nacimiento del paciente";
                return result;
            }
            if(entity.Gender == null)
            {
                result.Success = false;
                result.Message = "Es necesario saber el género del paciente";
                return result;
            }
            if(string.IsNullOrEmpty(entity.PhoneNumber) || entity.PhoneNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "Para comunicarnos es necesario el número telefónico del paciente y que no pase de 15 caracteres";
                return result;
            }
            if(string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 255)
            {
                result.Success = false;
                result.Message = "Se requiere la direcciónn del paciente y que no sobre pase de 255 caracteres";
                return result;
            }
            if(string.IsNullOrEmpty(entity.EmergencyContactName) || entity.EmergencyContactName.Length > 100)
            {
                result.Success = false;
                result.Message = "Se requiere el nombre de emergencia para el paciente y que no sobre pase de 100 caracteres";
                return result;
            }
            if (string.IsNullOrEmpty(entity.EmergencyContactPhone) || entity.EmergencyContactPhone.Length > 15)
            {
                result.Success = false;
                result.Message = "Se requiere el número de emergencia para el paciente y que sobre pase de 15 caracteres";
                return result;
            }
            if (entity.BloodType == null)
            {
                result.Success = false;
                result.Message = "Es requerido el tipo de sangre del paciente";
                return result;
            }
            if(entity.Allergies == null)
            {
                result.Success = false;
                result.Message = "Por la salud del paciente es necesario saber cuales son sus alergias";
                return result;
            }
            if(entity.InsuranceProviderID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el seguro del paciente";
            }
            if(await base.Exists(patient => patient.PatientID == entity.PatientID))
                {
                    result.Success = false;
                    result.Message = "El paciente ya  está registrado";
                    return result;
                }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el paciente";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Update(Patients entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El Id del paciente es requerido para esta función";
                return result;
            }
            if (entity.DateOfBirth == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha de nacimiento del paciente";
                return result;
            }
            if (entity.Gender == null)
            {
                result.Success = false;
                result.Message = "Es necesario saber el género del paciente";
                return result;
            }
                if (string.IsNullOrEmpty(entity.PhoneNumber) || entity.PhoneNumber.Length > 15)
                {
                    result.Success = false;
                    result.Message = "Para comunicarnos es necesario el número telefónico del paciente y que no pase de 15 caracteres";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length > 255)
                {
                    result.Success = false;
                    result.Message = "Se requiere la direcciónn del paciente y que no sobre pase de 255 caracteres";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.EmergencyContactName) || entity.EmergencyContactName.Length > 100)
                {
                    result.Success = false;
                    result.Message = "Se requiere el nombre de emergencia para el paciente y que no sobre pase de 100 caracteres";
                    return result;
                }
                if (string.IsNullOrEmpty(entity.EmergencyContactPhone) || entity.EmergencyContactPhone.Length > 15)
                {
                    result.Success = false;
                    result.Message = "Se requiere el número de emergencia para el paciente y que sobre pase de 15 caracteres";
                    return result;
                }
            if (entity.BloodType == null)
            {
                result.Success = false;
                result.Message = "Es requerido el tipo de sangre del paciente";
                return result;
            }
            if (entity.Allergies == null)
            {
                result.Success = false;
                result.Message = "Por la salud del paciente es necesario saber cuales son sus alergias";
                return result;
            }
            if (entity.InsuranceProviderID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el seguro del paciente";
                return result;
            }
            try
            {
                Patients? patients = await medical_AppointmentContext.Patients.FindAsync(entity.PatientID);
                patients.DateOfBirth = entity.DateOfBirth;
                patients.Gender = entity.Gender;
                patients.PhoneNumber = entity.PhoneNumber;
                patients.Address = entity.Address;
                patients.EmergencyContactName = entity.EmergencyContactName;
                patients.EmergencyContactPhone = entity.EmergencyContactPhone;
                patients.BloodType = entity.BloodType;
                patients.Allergies = entity.Allergies;
                patients.InsuranceProviderID = entity.InsuranceProviderID;
                patients.UserUpdate = entity.UserUpdate;

                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la información del Paciente";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(Patients entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el ID del paciente para realizar esta acción";
                return result;
            }
            try
            {
                Patients? patientsToRemove = await medical_AppointmentContext.Patients.FindAsync(entity.PatientID);
                patientsToRemove.IsActive = false;
                patientsToRemove.UpdatedAt = entity.UpdatedAt;
                patientsToRemove.UserUpdate = entity.UserUpdate;

                await base.Update(patientsToRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al desactivar al paciente";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from user in medical_AppointmentContext.Users
                                     join patient in medical_AppointmentContext.Patients on user.UserID equals patient.PatientID
                                     join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                     where patient.IsActive == true
                                     select new UserPatientModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Email = user.Email,
                                         Address = patient.Address,
                                         BloodType = patient.BloodType
                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los pacientes";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from user in medical_AppointmentContext.Users
                                     join patient in medical_AppointmentContext.Patients on user.UserID equals patient.PatientID
                                     join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                     where patient.IsActive == true
                                     && patient.PatientID == Id
                                     select new UserPatientModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Email = user.Email,
                                         Address = patient.Address,
                                         BloodType = patient.BloodType
                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el paciente";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> FindBloodType(char bloodType)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await(from user in medical_AppointmentContext.Users
                                    join patient in medical_AppointmentContext.Patients on user.UserID equals patient.PatientID
                                    join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                    where patient.IsActive == true
                                    && patient.BloodType == bloodType
                                    select new UserPatientModel()
                                    {
                                        FirstName = user.FirstName,
                                        LastName = user.LastName,
                                        DateOfBirth = patient.DateOfBirth,
                                        Gender = patient.Gender,
                                        PhoneNumber = patient.PhoneNumber,
                                        Email = user.Email,
                                        Address = patient.Address,
                                        BloodType = patient.BloodType
                                    }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los pacientes";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async Task<OperationResult> FindInsuranceProvider(int insuranceProviderId)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await(from user in medical_AppointmentContext.Users
                                    join patient in medical_AppointmentContext.Patients on user.UserID equals patient.PatientID
                                    join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                    where patient.IsActive == true
                                    && patient.InsuranceProviderID == insuranceProviderId
                                    select new UserPatientModel()
                                    {
                                        FirstName = user.FirstName,
                                        LastName = user.LastName,
                                        DateOfBirth = patient.DateOfBirth,
                                        Gender = patient.Gender,
                                        PhoneNumber = patient.PhoneNumber,
                                        Email = user.Email,
                                        Address = patient.Address,
                                        BloodType = patient.BloodType
                                    }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los pacientes";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async Task<OperationResult> FindGender(char gender)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await(from user in medical_AppointmentContext.Users
                                    join patient in medical_AppointmentContext.Patients on user.UserID equals patient.PatientID
                                    join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                    where patient.IsActive == true
                                    && patient.Gender == gender
                                    select new UserPatientModel()
                                    {
                                        FirstName = user.FirstName,
                                        LastName = user.LastName,
                                        DateOfBirth = patient.DateOfBirth,
                                        Gender = patient.Gender,
                                        PhoneNumber = patient.PhoneNumber,
                                        Email = user.Email,
                                        Address = patient.Address,
                                        BloodType = patient.BloodType
                                    }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los pacientes";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}