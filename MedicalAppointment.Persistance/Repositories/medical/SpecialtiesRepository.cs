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
    public sealed class SpecialtiesRepository(MedicalAppointmentContext medicalAppointmentContext, 
        ILogger<SpecialtiesRepository> logger) : BaseRepository<Specialties>(medicalAppointmentContext), ISpecialtiesRepository
    {
        private readonly MedicalAppointmentContext medicalAppointmentContext = medicalAppointmentContext;
        private readonly ILogger<SpecialtiesRepository> logger = logger;
        public async override Task<OperationResult> Save(Specialties entity)
        {
            OperationResult result = new OperationResult();
            if(entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if(string.IsNullOrEmpty(entity.SpecialtyName))
            {
                result.Success = false;
                result.Message = "el nombre de la especialidad es requerido";
                return result;
            }
            if(await base.Exists(specialty => specialty.SpecialtyID == entity.SpecialtyID) || await base.Exists(specialty => specialty.SpecialtyName == entity.SpecialtyName))
            {
                result.Success = false;
                result.Message = "La Especialidad ya exisite";
            }
            try
            {
                result = await base.Save(entity);
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Guardar la especialidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Update(Specialties entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if (entity.SpecialtyID <= 0)
            {
                result.Success = false;
                result.Message = "El Id es necesario para esta accion";
                return result;
            }
            if(string.IsNullOrEmpty(entity.SpecialtyName))
            {
                result.Success = false;
                result.Message = "El nombre de la especialidad es requerido";
                return result;
            }
            try
            {
                Specialties? specialtiesToUpdate = await medicalAppointmentContext.Specialties.FindAsync(entity.SpecialtyID);
                specialtiesToUpdate.SpecialtyName = entity.SpecialtyName;
               // specialtiesToUpdate.UserUpdate = entity.UserUpdate;

                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la especialidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> Remove(Specialties entity)
        {
            OperationResult result = new OperationResult();
            if (entity == null)
            {
                result.Success = false;
                result.Message = "La entidad es requerida";
                return result;
            }
            if(entity.SpecialtyID <= 0)
            {
                result.Success = false;
                result.Message = "Para realizar esta accion es necesario el ID";
                return result;
            }
            try
            {
                Specialties? specialtiesToRemove = await medicalAppointmentContext.Specialties.FindAsync(entity.SpecialtyID);
                specialtiesToRemove.IsActive = false;
                specialtiesToRemove.UpdatedAt = entity.UpdatedAt;
               // specialtiesToRemove.UserUpdate = entity.UserUpdate;

                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al remover la especialidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from specialties in medicalAppointmentContext.Specialties
                                     where specialties.IsActive == true
                                     select new SpecialtiesModel()
                                     {
                                         SpecialtyID = specialties.SpecialtyID,
                                         SpecialtyName = specialties.SpecialtyName
                                     }).AsNoTracking()
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al visualizar todas las especialidades";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await (from specialties in medicalAppointmentContext.Specialties
                                     where specialties.IsActive == true
                                     && specialties.SpecialtyID == Id
                                     select new SpecialtiesModel()
                                     {
                                         SpecialtyID = specialties.SpecialtyID,
                                         SpecialtyName = specialties.SpecialtyName
                                     }).AsNoTracking()
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al visualizar la especialidad";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
