using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            _context.SaveChanges();
        }

        public async Task CommmitAsync(CancellationToken cancellationToken =default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }   
}