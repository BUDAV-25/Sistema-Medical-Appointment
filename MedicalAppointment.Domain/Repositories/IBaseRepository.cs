﻿using MedicalAppointment.Domain.Result;
using System.Linq.Expressions;

namespace MedicalAppointment.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<OperationResult> Save(TEntity entity);
        Task<OperationResult> Update(TEntity entity);
        Task<OperationResult> Remove(TEntity entity);
        Task<OperationResult> GetAll();
        Task<OperationResult> GetEntityBy(int id);
        Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
