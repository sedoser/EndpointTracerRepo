using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.DataAccess.Uow
{
   public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken=default);

        void Commit();
    }
}