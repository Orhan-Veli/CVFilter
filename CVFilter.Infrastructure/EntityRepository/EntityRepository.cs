using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using CVFilter.Infrastructure.Context;
using CVFilter.Infrastructure.EntityRepository.Base;

namespace CVFilter.Infrastructure.EntityRepository
{
    public class EntityRepository<T> : IEntityRepository<T>
    where T : class, new()
    {
        private readonly CVFilterDbContext _cVFilterDbContext;
        public EntityRepository(CVFilterDbContext cVFilterDbContext)
        {
            _cVFilterDbContext = cVFilterDbContext;
        }
        public async Task Create(T model)
        {
            var addEnt = _cVFilterDbContext.Entry(model);
            addEnt.State = EntityState.Added;
        }

        public async Task Delete(T model)
        {
            var deletedEntity = _cVFilterDbContext.Entry(model);
            deletedEntity.State = EntityState.Deleted;
        }

        public async Task Update(T model)
        {
            var updateEntity = _cVFilterDbContext.Entry(model);
            updateEntity.State = EntityState.Modified;
        }

        public async Task<T> Get(Expression<Func<T,bool>> filter=null, List<Expression<Func<T, object>>> includeFilters = null)
        {
            if (includeFilters == null || includeFilters.Count == 0)
            {
                return filter == null
                    ? await _cVFilterDbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync()
                    : await _cVFilterDbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
            }
            else
            {
                var query = _cVFilterDbContext.Set<T>().AsQueryable();
                foreach (var item in includeFilters)
                {
                    query = query.Include(item);
                }
                return filter == null
                    ? await query.AsNoTracking().SingleOrDefaultAsync()
                    : await query.AsNoTracking().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T,bool>> filter=null)
        {
            return filter == null 
            ? _cVFilterDbContext.Set<T>().AsNoTracking().ToList()
            : _cVFilterDbContext.Set<T>().AsNoTracking().Where(filter).ToList();
        }

        public async Task<List<T>> GetAllQueryable(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includeFilters = null)
        {
            if (includeFilters == null || includeFilters.Count == 0)
            {
                return filter == null
                    ? await _cVFilterDbContext.Set<T>().AsNoTracking().ToListAsync()
                    : await _cVFilterDbContext.Set<T>().AsNoTracking().Where(filter).ToListAsync();
            }
            else
            {
                var query = _cVFilterDbContext.Set<T>().AsQueryable();
                foreach (var item in includeFilters)
                {
                    query = query.Include(item);
                }
                return filter == null
                    ? await query.AsNoTracking().ToListAsync()
                    : await query.AsNoTracking().Where(filter).ToListAsync();
            }
        }
    }
}