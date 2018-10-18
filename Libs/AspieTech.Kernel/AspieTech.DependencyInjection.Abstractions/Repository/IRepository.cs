using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspieTech.DependencyInjection.Abstractions.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task<IQueryable<TEntity>> Read();
        Task<bool> Update(TEntity entity);
        Task<bool> Destroy(TEntity entity);
        Task<int> ExecStoredProcedureWithoutReturn<TEntity>(IStoredProcedure<TEntity> sp) where TEntity : class;
        Task<IQueryable<TEntity>> ExecStoredProcedureWithReturn<TEntity>(IStoredProcedure<TEntity> sp) where TEntity : class;
    }
}
