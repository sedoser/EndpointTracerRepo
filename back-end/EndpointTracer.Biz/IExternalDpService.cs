using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;

namespace EndpointTracer.Biz
{
    public interface IExternalDpService
    {
        Task<ExternalDp> GetByIdAsync(int id);

        Task<IEnumerable<ExternalDp>> GetAllAsync();

        Task AddAsync(ExternalDp externaldp);

        Task RemoveAsync(int externalDpId);

        Task Update(ExternalDp externalDp);
    }
}