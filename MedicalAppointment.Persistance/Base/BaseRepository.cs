using MedicalAppointment.Domain.Repositories;
using MedicalAppointment.Domain.Result;
using MedicalAppointment.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalAppointment.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MedicalAppointmentContext medical_AppointmentContext;
        private DbSet<TEntity> entities;

        public BaseRepository(MedicalAppointmentContext medicalAppointmentContext)
        {
            medical_AppointmentContext = medicalAppointmentContext;
            this.entities = medical_AppointmentContext.Set<TEntity>();
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await this.entities.AnyAsync(filter);
        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                var datos = await this.entities.ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo todos los datos.";
            }

            return result;
        }
        public virtual async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            try
            {
                var entity = await this.entities.FindAsync(Id);
                result.Data = entity;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo la entidad.";
            }
            return result;
        }
        public virtual async Task<OperationResult> Remove(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Remove(entity);
                await medical_AppointmentContext.SaveChangesAsync();
            }
            catch( Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} eliminando la entidad.";
            }
            return result;
        }
        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Add(entity);
                await medical_AppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} guardando la entidad.";
            }
            return result;
        }
        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Update(entity);
                await medical_AppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} actualizando la entidad.";
            }
            return result;
        }
    }
}
