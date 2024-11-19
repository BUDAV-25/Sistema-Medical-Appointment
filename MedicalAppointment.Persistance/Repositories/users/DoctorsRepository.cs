using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.users
{
    public sealed class DoctorRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<DoctorRepository> logger) : BaseRepository<Doctor>(medicalAppointmentContext), IDoctorRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<DoctorRepository> logger = logger;
        public async override Task<OperationResult> Save(Doctor entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";

                return result;
            }
            if (entity.SpecialtyID == 0)
            {
                result.Success = false;
                result.Message = "La especialidad del es requerida";

                return result;
            }
            if (string.IsNullOrEmpty(entity.LicenseNumber) || entity.LicenseNumber.Length > 50)
            {
                result.Success = false;
                result.Message = "La licencia del doctor es requerida y no puede ser mayor 50 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(entity.PhoneNumber) || entity.PhoneNumber.Length > 15)
            {
                result.Success = false;
                result.Message = "Es necesario el número telefónico y no puede ser mayor a 15 caracteres.";
                return result;
            }
            if (entity.YearsOfExperience <= 0)
            {
                result.Success = false;
                result.Message = "Es necesario saber los años de experiencia";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Education))
            {
                result.Success = false;
                result.Message = "Es requerida la educación del doctor";
                return result;
            }
            if (entity.LicenseExpirationDate == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha en que expira la licencia";

                return result;
            }
            if (await base.Exists(doctor => doctor.DoctorID == entity.DoctorID))
            {
                result.Success = false;
                result.Message = "El doctor ya  está registrado";
                return result;
            }

            try
            {
                var doctorCreatedModel = await medical_AppointmentContext.Doctor.AddAsync(entity);

                result = await base.Save(entity);
               // result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar al doctor";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public async override Task<OperationResult> Update(Doctor entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el ID del doctor para realizar esta acción";
                return result;
            }
            if (entity.SpecialtyID == 0)
            {
                result.Success = false;
                result.Message = "La especialidad del es requerida";

                return result;
            }
            if (string.IsNullOrEmpty(entity.LicenseNumber) || entity.LicenseNumber.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La licencia del doctor es requerida y no puede ser mayor 50 caracteres.";
                    return result;
                }
            if (string.IsNullOrEmpty(entity.PhoneNumber) || entity.PhoneNumber.Length > 15)
                {
                    result.Success = false;
                    result.Message = "Es necesario el número telefónico y no puede ser mayor a 15 caracteres.";
                    return result;
                }
            if (entity.YearsOfExperience <= 0)
            {
                result.Success = false;
                result.Message = "Es necesario saber los años de experiencia";
                return result;
            }
            if (string.IsNullOrEmpty(entity.Education))
                {
                    result.Success = false;
                    result.Message = "Es requerida la educación del doctor";
                    return result;
            }
                if (entity.LicenseExpirationDate == null)
            {
                result.Success = false;
                result.Message = "Se requiere la fecha en que expira la licencia";

                return result;
            }
            try
            {
                Doctor? doctorUpdate = await medical_AppointmentContext.Doctor.FindAsync(entity.DoctorID);
                doctorUpdate.SpecialtyID = entity.SpecialtyID;
                doctorUpdate.LicenseNumber = entity.LicenseNumber;
                doctorUpdate.PhoneNumber = entity.PhoneNumber;
                doctorUpdate.YearsOfExperience = entity.YearsOfExperience;
                doctorUpdate.Education = entity.Education;
                doctorUpdate.Bio = entity.Bio;
                doctorUpdate.ConsultationFee = entity.ConsultationFee;
                doctorUpdate.ClinicAddress = entity.ClinicAddress;
                doctorUpdate.AvailabilityModeId = entity.AvailabilityModeId;
                doctorUpdate.LicenseExpirationDate = entity.LicenseExpirationDate;
                //doctorUpdate.UserUpdate = entity.UserUpdate;

                result = await base.Update(doctorUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la información del doctor";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(Doctor entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "Se requiere la entidad";
                return result;
            }
            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "Es requerido el ID del doctor para realizar esta acción";
                return result;
            }
            try
            {
                Doctor? doctorToRemove = await medical_AppointmentContext.Doctor.FindAsync(entity.DoctorID);
                doctorToRemove.IsActive = false;
                doctorToRemove.UpdatedAt = entity.UpdatedAt;
              //  doctorToRemove.UserUpdate = entity.UserUpdate;

                await base.Update(doctorToRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al desactivar al doctor";
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
                                     join doctor in medical_AppointmentContext.Doctor on user.UserID equals doctor.DoctorID
                                     join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                     join availability in medical_AppointmentContext.AvailabilityModes on doctor.AvailabilityModeId equals availability.SAvailabilityModeID
                                     where doctor.IsActive == true
                                     orderby doctor.CreatedAt descending
                                     select new DoctorsModel()
                                     {
                                         DoctorID = doctor.DoctorID,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         SpecialtyName = specialty.SpecialtyName,
                                         AvailabilityMode = availability.AvailabilityMode,
                                         ConsultationFee = doctor.ConsultationFee,
                                         PhoneNumber = doctor.PhoneNumber,
                                         ClinicAddress = doctor.ClinicAddress,
                                         Email = user.Email
                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = "Error al obtener los doctores";
                logger.LogError(result.Message, e.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from user in medical_AppointmentContext.User
                                     join doctor in medical_AppointmentContext.Doctor on user.UserID equals doctor.DoctorID
                                     join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                     join availability in medical_AppointmentContext.AvailabilityModes on doctor.AvailabilityModeId equals availability.SAvailabilityModeID
                                     where doctor.DoctorID == Id
                                     select new DoctorDetailsModel()
                                     {
                                         DoctorID = doctor.DoctorID,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         SpecialtyID = doctor.SpecialtyID,
                                         SpecialtyName = specialty.SpecialtyName,
                                         Email = user.Email,
                                         LicenseNumber = doctor.LicenseNumber,
                                         PhoneNumber = doctor.PhoneNumber,
                                         YearsOfExperience = doctor.YearsOfExperience,
                                         Education = doctor.Education,
                                         Bio = doctor.Bio,
                                         ConsultationFee = doctor.ConsultationFee,
                                         ClinicAddress = doctor.ClinicAddress,
                                         AvailabilityModeId = doctor.AvailabilityModeId,
                                         AvailabilityMode = availability.AvailabilityMode,
                                         LicenseExpirationDate = doctor.LicenseExpirationDate,
                                         IsActive = doctor.IsActive

                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Doctor.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> FindDoctorSpecialty(short specialtyID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await(from user in medical_AppointmentContext.User
                                    join doctor in medical_AppointmentContext.Doctor on user.UserID equals doctor.DoctorID
                                    join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                    where doctor.IsActive == true
                                    && doctor.SpecialtyID == specialtyID
                                    select new UserDoctorModel()
                                    {
                                        FirstName = user.FirstName,
                                        LastName = user.LastName,
                                        SpecialtyName = specialty.SpecialtyName,
                                        LicenseNumber = doctor.LicenseNumber,
                                        PhoneNumber = doctor.PhoneNumber,
                                        Email = user.Email
                                    }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Doctor.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async Task<OperationResult> FindSpecialityAvailability(short specialtyID, short availabilityModeId)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from user in medical_AppointmentContext.User
                                     join doctor in medical_AppointmentContext.Doctor on user.UserID equals doctor.DoctorID
                                     join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                     where doctor.IsActive == true
                                     && doctor.SpecialtyID == specialtyID && doctor.AvailabilityModeId == availabilityModeId
                                     select new UserDoctorModel()
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         SpecialtyName = specialty.SpecialtyName,
                                         LicenseNumber = doctor.LicenseNumber,
                                         PhoneNumber = doctor.PhoneNumber,
                                         Email = user.Email
                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Doctor.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async Task<OperationResult> getDoctorsByAvailabilityMode(short availabilityModeId)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await(from user in medical_AppointmentContext.User
                                    join doctor in medical_AppointmentContext.Doctor on user.UserID equals doctor.DoctorID
                                    join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                    where doctor.IsActive == true
                                    && doctor.AvailabilityModeId == availabilityModeId
                                    select new UserDoctorModel()
                                    {
                                        FirstName = user.FirstName,
                                        LastName = user.LastName,
                                        SpecialtyName = specialty.SpecialtyName,
                                        LicenseNumber = doctor.LicenseNumber,
                                        PhoneNumber = doctor.PhoneNumber,
                                        Email = user.Email
                                    }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el Doctor.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
