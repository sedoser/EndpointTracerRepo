using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.Biz.Exceptions;
using EndpointTracer.Core.Exceptions;
using EndpointTracer.DataAccess;
using EndpointTracer.DataAccess.Repositories;
using EndpointTracer.DataAccess.Uow;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EndpointTracer.Biz
{
    public class ExternalDpService : IExternalDpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ExternalDp> _externalDpRepository;


        public ExternalDpService(IRepository<ExternalDp> ExternalDpRepository, IUnitOfWork unitOfWork)
        {
            _externalDpRepository = ExternalDpRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExternalDp> AddAsync(ExternalDp externalDp)
        {
            if (externalDp == null)
            {
                throw new CustomException("ExternalDp name cannot be null.");
            }
            if (string.IsNullOrEmpty(externalDp.DpName))
            {
                throw new CustomException("ExternalDp name cannot be empty.");
            }

            await _externalDpRepository.AddAsync(externalDp);

            await _unitOfWork.CommitAsync();

            return externalDp;

        }
        public async Task<ExternalDp> Update(ExternalDp externalDp)
        {

            ExternalDp updatedExternalDp = _externalDpRepository.Update(externalDp);

            await _unitOfWork.CommitAsync();

            return updatedExternalDp;
        }
        public async Task<IEnumerable<ExternalDp>> GetAllAsync()
        {
            return await _externalDpRepository.GetAllAsync();
        }
        public async Task<ExternalDp> GetByIdAsync(int id)
        {
            var externalDp = await _externalDpRepository.Where(x => x.ExternalDpId == id).Include(x=>x.EndpointAddresses).Include(x=>x.Certificates).FirstOrDefaultAsync();  
             if (externalDp == null)
            {
                throw new CustomException($"ExternalDp not found with id:{id}.");
            }
            return externalDp;
        }
        public async Task RemoveAsync(int externalDpId)
        {
            var externalDp = await _externalDpRepository.Where(x => x.ExternalDpId == externalDpId).Include(x=>x.EndpointAddresses).Include(x=>x.Certificates).FirstOrDefaultAsync();  

            if (externalDp == null)
            {
                throw new CustomException($"ExternalDp not found with id:{externalDpId}.");
            }

            _externalDpRepository.Remove(externalDp);

            await _unitOfWork.CommitAsync();
        }
    }
}