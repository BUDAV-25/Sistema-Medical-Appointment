

using Azure.Core;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Entities.users;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.appointments;
using MedicalAppointment.Persistance.Models;
using MedicalAppointment.Persistance.Models.appointments;
using MedicalAppointment.Persistance.Validations.appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.appointments
{
    public sealed class DoctorAvailabilityRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<DoctorAvailabilityRepository> logger, ValidateDoctorAvailability validateDoctorAvailability) : BaseRepository<DoctorAvailability>(medicalAppointmentContext), IDoctorAvailabilityRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<DoctorAvailabilityRepository> logger = logger;
        private readonly ValidateDoctorAvailability _doctorAvailability = validateDoctorAvailability;

        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            _doctorAvailability.ValidationSaveDoctorAvailability(entity, result);

            if (await base.Exists(doctorAvailability => doctorAvailability.AvailabilityID == entity.AvailabilityID
            && doctorAvailability.DoctorID == entity.DoctorID))
            {
                result.Success = false;
                result.Message = "Este registro ya existe.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al crear el registro";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Update(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            _doctorAvailability.ValidationUpdateDoctorAvailability(entity, result);

            try
            {
                DoctorAvailability? doctorAvailabilityToUpdate = await medical_AppointmentContext.DoctorAvailability.FindAsync(entity.AvailabilityID);

                doctorAvailabilityToUpdate.AvailabilityID = entity.AvailabilityID;
                doctorAvailabilityToUpdate.DoctorID = entity.DoctorID;
                doctorAvailabilityToUpdate.AvailableDate = entity.AvailableDate;
                doctorAvailabilityToUpdate.StartTime = entity.StartTime;
                doctorAvailabilityToUpdate.EndTime = entity.EndTime;

                result = await base.Update(doctorAvailabilityToUpdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar disponibilidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> Remove(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            _doctorAvailability.ValidationRemoveDoctorAvailability(entity, result);

            try
            {
                DoctorAvailability? doctorAvailabilityToRemove = await medical_AppointmentContext.DoctorAvailability.FindAsync(entity.AvailabilityID);
                doctorAvailabilityToRemove.AvailabilityID = entity.AvailabilityID;
                doctorAvailabilityToRemove.DoctorID = entity.DoctorID;
                doctorAvailabilityToRemove.AvailableDate = entity.AvailableDate;
                doctorAvailabilityToRemove.StartTime = entity.StartTime;
                doctorAvailabilityToRemove.EndTime = entity.EndTime;

                await base.Update(doctorAvailabilityToRemove);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover la disponibilidad.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> GetAll()
        {

            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from availability in medical_AppointmentContext.DoctorAvailability
                                     join doctor in medical_AppointmentContext.Doctor on availability.DoctorID equals doctor.DoctorID
                                     orderby availability.AvailabilityID descending

                                     select new DoctorAvailabilityModel()

                                     {
                                         AvailabilityID = availability.AvailabilityID,
                                         DoctorID = doctor.DoctorID,
                                         AvailableDate = availability.AvailableDate,
                                         StartTime = availability.StartTime,
                                         EndTime = availability.EndTime

                                     }).AsNoTracking()
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las disponibilidades";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }


        public async override Task<OperationResult> GetEntityBy(int ID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from availability in medical_AppointmentContext.DoctorAvailability
                                     join doctor in medical_AppointmentContext.Doctor on availability.DoctorID equals doctor.DoctorID
                                     where availability.AvailabilityID == ID
                                     select new DoctorAvailabilityModel()
                                     {
                                         AvailabilityID = availability.AvailabilityID,
                                         DoctorID = doctor.DoctorID,
                                         AvailableDate = availability.AvailableDate,
                                         StartTime = availability.StartTime,
                                         EndTime = availability.EndTime

                                     }).AsNoTracking()
                                      .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el dato espesifico";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public Task<OperationResult> SetDoctorAvailability(int doctorId, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> BlockDoctorTimeSlot(int doctorId, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAvailabilityByDoctor(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAvailabilityForDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateAvailabilityForDoctor(int doctorId, List<DoctorAvailability> availabilities)
        {
            throw new NotImplementedException();
        }
    }
}
