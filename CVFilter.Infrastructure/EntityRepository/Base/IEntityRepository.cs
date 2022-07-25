using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CVFilter.Infrastructure.Context;

namespace CVFilter.Infrastructure.EntityRepository.Base
{
    public interface IEntityRepository<T> where T : class,new()
    {
        Task Create(T model);
        Task Delete(T model);
        Task Update(T model);
        Task<T> Get(Expression<Func<T,bool>> filter=null);
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter=null);
    }
}