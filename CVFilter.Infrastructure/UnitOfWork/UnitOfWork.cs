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
        public UnitOfWork(CVFilterDbContext cvFilterDbContext)
        {
            _cvFilterDbContext = cvFilterDbContext;
            
        }
        public void Commit(bool state = true)
        {
            _cvFilterDbContext.SaveChanges();
            //Dispose();
        }
        public void Dispose()
        {
            _cvFilterDbContext.Dispose();
        }
    }
}