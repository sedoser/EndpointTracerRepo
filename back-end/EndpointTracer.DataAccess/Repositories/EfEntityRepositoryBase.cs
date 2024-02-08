

using System.Linq.Expressions;
using EndpointTracer.DataAccess;
using EndpointTracer.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EndpointTracer.DataAccess.Repositories;

public class EfEntityRepositoryBase<Tentity> : IRepository<Tentity> where Tentity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<Tentity> _dbSet;

        public EfEntityRepositoryBase(EndpointTracerContext context)
        {
            _context = context;
            _dbSet = context.Set<Tentity>();
        }

        public async Task AddAsync(Tentity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            
            return entity!;
        }

        public void Remove(Tentity entity)
        {
            _dbSet.Remove(entity);
        }

        public Tentity Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public IQueryable<Tentity> Where(Expression<Func<Tentity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }