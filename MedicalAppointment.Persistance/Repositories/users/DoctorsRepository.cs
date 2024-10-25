using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.users;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.users
{
    public sealed class DoctorsRepository(MedicalAppointmentContext medicalAppointmentContext,
        ILogger<DoctorsRepository> logger) : BaseRepository<Doctors>(medicalAppointmentContext), IDoctorsRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<DoctorsRepository> logger = logger;
        public async override Task<OperationResult>Save(Doctors entity)
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
            if(entity.LicenseNumber == null)
            {
                result.Success = false;
                result.Message = "La licencia del doctor es requerida";
                return result;
            }
            if(entity.PhoneNumber == null)
            {
                result.Success = false;
                result.Message = "Es necesario el número telefónico";
                return result;
            }
            if(entity.YearsOfExperience <= 0)
            {
                result.Success = false;
                result.Message = "Es necesario saber los años de experiencia";
                return result;
            }
            if(entity.Education == null)
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
            if (await base.Exists(doctor => doctor.DoctorID == entity.DoctorID && doctor.SpecialtyID == entity.SpecialtyID))
            {
                result.Success = false;
                result.Message = "El doctor ya  está registrado";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar al doctor";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public async override Task<OperationResult>Update(Doctors entity)
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
            if (entity.LicenseNumber == null)
            {
                result.Success = false;
                result.Message = "La licencia del doctor es requerida";
                return result;
            }
            if (entity.PhoneNumber == null)
            {
                result.Success = false;
                result.Message = "Es necesario el número telefónico";
                return result;
            }
            if (entity.YearsOfExperience <= 0)
            {
                result.Success = false;
                result.Message = "Es necesario saber los años de experiencia";
                return result;
            }
            if (entity.Education == null)
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
                Doctors? doctorUpdate = await medical_AppointmentContext.Doctors.FindAsync(entity.DoctorID);
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
                doctorUpdate.UserUpdate = entity.UserUpdate;

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
        public async override Task<OperationResult>Remove(Doctors entity)
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
                Doctors? doctorToRemove = await medical_AppointmentContext.Doctors.FindAsync(entity.DoctorID);
                doctorToRemove.IsActive = false;
                doctorToRemove.UpdatedAt = entity.UpdatedAt;
                doctorToRemove.UserUpdate = entity.UserUpdate;

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
       /* public async override Task<OperationResult> GetAll(Doctors entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from doctor in medical_AppointmentContext.Doctors
                                     join specialty in medical_AppointmentContext.Specialties on doctor.SpecialtyID equals specialty.SpecialtyID
                                     join availability in medical_AppointmentContext.DoctorAvailability on doctor.AvailabilityModeId equals availability.AvailabilityID
                                     where doctor.IsActive == true
                                     orderby doctor.CreatedAt descending
                                     select new DoctorSpecialtyAvailabilityModel()
                                     {

                                     });
            }
        }*/

        public Task<OperationResult> FindDoctorSpecialty(short specialtyID)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> FindSpecialityAvailability(short specialtyID, short availabilityModeId)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> getDoctorsByAvailabilityMode(short availabilityModeId)
        {
            throw new NotImplementedException();
        }
    }
}
