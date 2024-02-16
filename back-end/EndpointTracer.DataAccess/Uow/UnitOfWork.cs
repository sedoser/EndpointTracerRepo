using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EndpointTracer.Core.Exceptions;

namespace EndpointTracer.DataAccess.Uow
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(EndpointTracerContext context) { 
            _context = context;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UowException("Error when committing the Uow", ex);
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken =default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UowException("Error when committing the Uow", ex);
            }
        }
    }   
}