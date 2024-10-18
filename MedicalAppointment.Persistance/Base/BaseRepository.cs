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
        public async Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                var exists = await this.entities.AnyAsync(filter);
                result.Data = exists;
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} verificando que existe el registro.";
            }

            return result;
        }
        public Task<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> Save(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<OperationResult> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
