using MedicalAppointment.Domain.Entities.medical;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.medical;
using MedicalAppointment.Persistance.Models.medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.medical
{
    public sealed class AvailabilityModesRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<AvailabilityModesRepository> logger) : BaseRepository<AvailabilityModes>(medicalAppointmentContext), IAvailabilityModesRepository
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<AvailabilityModesRepository> logger = logger;
        public async override Task<OperationResult> Save(AvailabilityModes entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(entity.AvailabilityMode) || entity.AvailabilityMode.Length > 100)
            {
                result.Success = false;
                result.Message = "El modo es necesario y debe ser menor a 100 caracteres";
                return result;
            }
            if (await base.Exists(availability => availability.SAvailabilityModeID == entity.SAvailabilityModeID))
            {
                result.Success = false;
                result.Message = "El Modo ya est[a registrado";
                return result;
            }
            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el modo";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Update(AvailabilityModes entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(entity.AvailabilityMode) || entity.AvailabilityMode.Length > 100)
            {
                result.Success = false;
                result.Message = "El modo es necesario y debe ser menor a 100 caracteres";
                return result;
            }
            try
            {
                AvailabilityModes? availabilityToUpdate = await medical_AppointmentContext.AvailabilityModes.FindAsync(entity.SAvailabilityModeID);

                availabilityToUpdate.AvailabilityMode = entity.AvailabilityMode;
                availabilityToUpdate.UpdatedAt = entity.UpdatedAt;
                availabilityToUpdate.IsActive = entity.IsActive;

                result = await base.Update(availabilityToUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el modo";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(AvailabilityModes entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if(entity.SAvailabilityModeID <= 0)
            {
                result.Success = false;
                result.Message = "El Id es necesario para esta acción";
                return result;
            }
            try
            {
                AvailabilityModes? availabilityToRemove = await medical_AppointmentContext.AvailabilityModes.FindAsync(entity.SAvailabilityModeID);
                availabilityToRemove.IsActive = false;
                availabilityToRemove.UpdatedAt = entity.UpdatedAt;

                result = await base.Update(availabilityToRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el modo";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from availability in medical_AppointmentContext.AvailabilityModes
                                     orderby availability.CreatedAt descending
                                     select new AvailabilityModesModel()
                                     {
                                         SAvailabilityModeID = availability.SAvailabilityModeID,
                                         AvailabilityMode = availability.AvailabilityMode,
                                         CreatedAt = availability.CreatedAt,
                                         UpdatedAt = availability.UpdatedAt,
                                         IsActive = availability.IsActive
                                     }).AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los modos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from availability in medical_AppointmentContext.AvailabilityModes
                                     where availability.SAvailabilityModeID == id
                                     orderby availability.CreatedAt descending
                                     select new AvailabilityModesModel()
                                     {
                                         SAvailabilityModeID = availability.SAvailabilityModeID,
                                         AvailabilityMode = availability.AvailabilityMode,
                                         CreatedAt = availability.CreatedAt,
                                         UpdatedAt = availability.UpdatedAt,
                                         IsActive = availability.IsActive
                                     }).AsNoTracking()
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el modo";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
