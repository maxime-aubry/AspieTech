using System.Linq;
using System.Threading.Tasks;

namespace AspieTech.DependencyInjection.Abstractions.Repository
{
    public interface IRepository
    {
        Task Create<TEntity>(TEntity entity) where TEntity : class;
        Task<IQueryable<TEntity>> Read<TEntity>() where TEntity : class;
        Task<bool> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> Destroy<TEntity>(TEntity entity) where TEntity : class;
    }
}
