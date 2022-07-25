using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVFilter.Infrastructure.UnitOfWork.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit(bool state = true);
        void Dispose();
    }
}