using IHunger.Services.Restaurants.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IHunger.Services.Restaurants.Core.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntityBase
    {
        Task Add(TEntity entity);
        Task<TEntity?> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<List<TEntity>> Search(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? pageSize = null,
            int? pageIndex = null);
    }
}
