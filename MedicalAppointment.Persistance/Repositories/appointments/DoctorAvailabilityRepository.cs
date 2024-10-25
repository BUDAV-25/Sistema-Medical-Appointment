

using Azure.Core;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace MedicalAppointment.Persistance.Repositories.appointments
{
    public sealed class DoctorAvailabilityRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<DoctorAvailabilityRepository> logger) : BaseRepository<DoctorAvailability>(medicalAppointmentContext), IDoctorAvailabilityRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<DoctorAvailabilityRepository> logger = logger;

        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null) {
            result.Success = false;
            result.Message = "La entidad es requerida.";
            return result;
            
            }

            if (entity.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El doctor es requerido.";
                return result;
            }
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
            
            if (entity == null) {
                result.Success = false;
                result.Message = "La entidad es requerida.";
                return result;
            }

            if (entity.AvailabilityID <= 0)
            {
                result.Success = false;
                result.Message = "La disponivilidad es requerida.";
                return result;
            }

            if (entity.DoctorID <= 0){
                result.Success = false;
                result.Message = "Es requerido el ID del doctor para realizar esta acción.";
                return result;
            }

            if (entity.AvailableDate == null){
                result.Success = false;
                result.Message = "La fecha es requerida.";
                return result;
            }

            if (entity.StartTime == null){
                result.Success = false;
                result.Message = "La fecha inicial es requerida.";
                return result;
            }

            if (entity.EndTime == null){
                result.Success = false;
                result.Message = "La fecha final es requerida.";
                return result;
            }

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
            catch (Exception ex) {
                result.Success = false;
                result.Message = "Error al actualizar disponibilidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async override Task<OperationResult> Remove(DoctorAvailability entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null){
                result.Success = false;
                result.Message = "La entidad es requerida.";
                return result;
            }

            if (entity.AvailabilityID <= 0) { 
                result.Success = false;
                result.Message = "Se requiere el ID de la disponibilidad para realizar esta acción.";
                return result; 
            }

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

        /*
        public async override Task<OperationResult> GetEntityBy(int AvailabilityID)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from availability in medicalAppointmentContext
                                     join doctor in medicalAppointmentContext.Doctors on availability.DoctorId equals doctor.Id
                                     where availability.Id == AvailabilityID
                                     select new DoctorAvailabilityModel()
                                     {
                                         AvailabilityId = availability.Id,
                                         DoctorId = doctor.Id,
                                         DoctorName = doctor.Name,
                                         StartDateTime = availability.StartDateTime,
                                         EndDateTime = availability.EndDateTime,
                                         IsAvailable = availability.IsAvailable,
                                         CreatedAt = availability.CreatedAt,
                                         ModifiedAt = availability.ModifiedAt
                                     }).FirstOrDefaultAsync();

                result.Success = result.Data != null;
                result.Message = result.Data != null ? "Doctor availability data retrieved successfully." : "No availability found with the specified ID.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error retrieving doctor availability data.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        */


        public Task<OperationResult> BlockDoctorTimeSlot(int doctorId, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> SetDoctorAvailability(int doctorId, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }
    }
}
