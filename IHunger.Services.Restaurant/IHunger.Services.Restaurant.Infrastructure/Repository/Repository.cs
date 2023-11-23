using IHunger.Services.Restaurants.Core.Entities;
using IHunger.Services.Restaurants.Core.Repositories;
using IHunger.Services.Restaurants.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IHunger.Services.Restaurants.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot, new()
    {
        protected readonly RestaurantDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected int Count;

        protected Repository(RestaurantDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
            Count = DbSet.AsQueryable().Count();
        }

        public virtual async Task Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await DbSet.AddAsync(entity);

            await Db.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> Search(
            Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
            int? pageSize = null, int? pageIndex = null)
        {
            var query = DbSet.AsQueryable();
            Count = query.Count();
            int pages = 0;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (pageSize != null && pageSize.HasValue && pageSize > 0)
            {
                pages = Count / pageSize.Value;

                if (pageIndex != null && pageIndex.HasValue && pageIndex.Value > 0)
                {
                    if (pageIndex.Value > pages)
                    {
                        query = query.OrderBy(x => x.Id).Skip(pageSize.Value * pages).Take(pageSize.Value);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Id).Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
                    }

                }
                else
                {
                    query = query.OrderBy(x => x.Id).Skip(pageSize.Value);
                }

            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            DbSet.Update(entity);

            await Db.SaveChangesAsync();
        }

        public virtual async Task Remove(Guid id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
            {
                entity.DeletedAt = DateTime.Now;
                await Update(entity);
            }
        }

        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
}
