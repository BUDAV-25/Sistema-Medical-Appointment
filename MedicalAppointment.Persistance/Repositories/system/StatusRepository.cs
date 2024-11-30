using MedicalAppointment.Domain.Entities.system;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Base;
using MedicalAppointment.Persistance.Context;
using MedicalAppointment.Persistance.Interfaces.system;
using MedicalAppointment.Persistance.Models.system;
using MedicalAppointment.Persistance.Validations.system;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistance.Repositories.system
{
    public sealed class StatusRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<StatusRepository> logger, ValidateStatus validateStatus) : BaseRepository<Status>(medicalAppointmentContext), IStatusRepository
    {

        private readonly MedicalAppointmentContext medical_AppointmentContext = medicalAppointmentContext;
        private readonly ILogger<StatusRepository> logger = logger;
        private readonly ValidateStatus _validateStatus = validateStatus;

        public async override Task<OperationResult> Save(Status entity)
        {
            OperationResult result = new OperationResult();

            _validateStatus.ValidationSaveStatus(entity, result);

            try
            {
                await base.Save(entity);
                result.Data = entity;
                result.Message = "Status saved succefully!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el Status";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Update(Status entity)
        {
            OperationResult result = new OperationResult();

            _validateStatus.ValidationUpdateStatus(entity, result);

            try
            {
                Status? statusToUpdate = await medical_AppointmentContext.Status.FindAsync(entity.StatusID);

                statusToUpdate.StatusID = entity.StatusID;
                statusToUpdate.StatusName = entity.StatusName;

                result = await base.Update(statusToUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el Status";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> Remove(Status entity)
        {
            OperationResult result = new OperationResult();

            _validateStatus.ValidationRemoveStatus(entity, result);

            try
            {
                Status? statusToRemove = await medical_AppointmentContext.Status.FindAsync(entity.StatusID);

                statusToRemove.StatusID = entity.StatusID;
                statusToRemove.StatusName = entity.StatusName;

                result = await base.Update(statusToRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover el Status";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from status in medical_AppointmentContext.Status
                                     orderby status.StatusID descending

                                     select new StatusModel()

                                     {
                                         StatusID = status.StatusID,
                                         StatusName = status.StatusName

                                     }).AsNoTracking()
                                   .ToListAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from status in medical_AppointmentContext.Status
                                     where status.StatusID == id
                                     select new StatusModel()

                                     {
                                         StatusID = status.StatusID,
                                         StatusName = status.StatusName

                                     }).AsNoTracking()
                                   .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public Task<OperationResult> GetActiveStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetStatusesByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
