using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVFilter.Infrastructure.UnitOfWork.Base;
using CVFilter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CVFilter.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CVFilterDbContext _cvFilterDbContext;
        private readonly IDbContextTransaction _transaction = null;
        public UnitOfWork(CVFilterDbContext cvFilterDbContext)
        {
            _cvFilterDbContext = cvFilterDbContext;
            _transaction = _cvFilterDbContext.Database.BeginTransaction();
            
        }
        public void Commit(bool state = true)
        {
            _cvFilterDbContext.SaveChanges();
            if(state) _transaction.Commit(); 
            else _transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            _cvFilterDbContext.Dispose();
        }
    }
}