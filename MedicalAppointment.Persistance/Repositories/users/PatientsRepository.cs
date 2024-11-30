using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Models.users;
using MedicalAppointment.Persistance.Repositories.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.users
{
    public sealed class PatientsRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<PatientsRepository> logger, ValidateUsers validateUsers) : BaseRepository<Patient>(medicalAppointmentContext), IPatientRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<PatientsRepository> logger = logger;
        private readonly ValidateUsers validatePatient = validateUsers;
        public async override Task<OperationResult> Save(Patient entity)
        {
            OperationResult result = new OperationResult();
            
            validatePatient.ValidationsPatient(entity, result);

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
        public async override Task<OperationResult> Update(Patient entity)
        {
            OperationResult result = new OperationResult();
            if (entity.PatientID <= 0)
            {
                result.Success = false;
                result.Message = "El Id del paciente es requerido para esta función";
                return result;
            }

            validatePatient.ValidationsPatient(entity, result);
            
            try
            {
                Patient? patient = await medical_AppointmentContext.Patient.FindAsync(entity.PatientID);

                patient.DateOfBirth = entity.DateOfBirth;
                patient.Gender = entity.Gender;
                patient.PhoneNumber = entity.PhoneNumber;
                patient.Address = entity.Address;
                patient.EmergencyContactName = entity.EmergencyContactName;
                patient.EmergencyContactPhone = entity.EmergencyContactPhone;
                patient.BloodType = entity.BloodType;
                patient.Allergies = entity.Allergies;
                patient.InsuranceProviderID = entity.InsuranceProviderID;
                //patients.UserUpdate = entity.UserUpdate;

                result = await base.Update(patient);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la información del Paciente";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(Patient entity)
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
                Patient? patientToRemove = await medical_AppointmentContext.Patient.FindAsync(entity.PatientID);
                patientToRemove.IsActive = false;
                patientToRemove.UpdatedAt = entity.UpdatedAt;
               // patientsToRemove.UserUpdate = entity.UserUpdate;

                await base.Update(patientToRemove);
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
                result.Data = await (from user in medical_AppointmentContext.User
                                     join patient in medical_AppointmentContext.Patient on user.UserID equals patient.PatientID
                                     join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                     where patient.IsActive == true
                                     select new UserPatientModel()
                                     {
                                         PatientID = patient.PatientID,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Email = user.Email,
                                         Address = patient.Address
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
                result.Data = await (from user in medical_AppointmentContext.User
                                     join patient in medical_AppointmentContext.Patient on user.UserID equals patient.PatientID
                                     join insuranceP in medical_AppointmentContext.InsuranceProviders on patient.InsuranceProviderID equals insuranceP.InsuranceProviderID
                                     where patient.IsActive == true
                                     && patient.PatientID == Id
                                     select new UserPatientModel()
                                     {
                                         PatientID = patient.PatientID,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Email = user.Email,
                                         Address = patient.Address,
                                         BloodType = patient.BloodType,
                                         EmergencyContactName = patient.EmergencyContactName,
                                         EmergencyContactPhone = patient.EmergencyContactPhone,
                                         Allergies = patient.Allergies,
                                         InsuranceProviderID = insuranceP.InsuranceProviderID,
                                         InsuranceProviderName = insuranceP.Name,
                                         IsActive = patient.IsActive
                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();
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
                result.Data = await(from user in medical_AppointmentContext.User
                                    join patient in medical_AppointmentContext.Patient on user.UserID equals patient.PatientID
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
                result.Data = await(from user in medical_AppointmentContext.User
                                    join patient in medical_AppointmentContext.Patient on user.UserID equals patient.PatientID
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
                result.Data = await(from user in medical_AppointmentContext.User
                                    join patient in medical_AppointmentContext.Patient on user.UserID equals patient.PatientID
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
