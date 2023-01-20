using Infrastructure.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");

        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}