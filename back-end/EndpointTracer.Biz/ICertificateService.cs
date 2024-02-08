using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EndpointTracer.Model;

namespace EndpointTracer.Biz
{
    public interface ICertificateService
    {
        Task<Certificate> GetByIdAsync(int id);

        Task<IEnumerable<Certificate>> GetAllAsync();

        Task AddAsync(Certificate certificate);

        void Remove(Certificate certificate);

        Task Update(Certificate certificate);
    }
}