using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.Biz.Exceptions;
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
                throw new ArgumentNullException(nameof(externalDp));
            }    
            if (string.IsNullOrEmpty(externalDp.DpName))
            {
                throw new ValidationException("DpName property cannot be empty.");
            }
            try
            {
                await _externalDpRepository.AddAsync(externalDp); await _unitOfWork.CommitAsync();//bitane m fazla
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error when adding the ExternalDp", ex);
            }
            return externalDp;
            
        }
        public async Task<ExternalDp> Update(ExternalDp externalDp)
        {
            var existingExternalDp = await _externalDpRepository.GetByIdAsync(externalDp.ExternalDpId);
            if (existingExternalDp == null)
            {
                throw new KeyNotFoundException($"A ExternalDp with the ID {externalDp.ExternalDpId} was not found.");
            }
            try
            {
                _externalDpRepository.Update(externalDp);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating the ExternalDp", ex);
            }
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (DbException ex)
            {
                throw new DbUpdateException("Error when writing to database", ex);
            }
            return externalDp;
        }
        public async Task<IEnumerable<ExternalDp>> GetAllAsync()
        {
            return await _externalDpRepository.GetAllAsync();
        }

//async metotlar için CancellationToken kullanılabilir.
        public async Task<ExternalDp> GetByIdAsync(int id)
        {
            var externalDp = await _externalDpRepository.GetByIdAsync(id);
                if (externalDp == null)
                {
                    //@todo:Custom bir exception sınıfı yazılacak. for ex: CustomException
                    throw new IdNotFoundException(id);
                }
                return externalDp;
        }    
        public async Task RemoveAsync(int externalDpId)
        {
            var externalDp = await _externalDpRepository.GetByIdAsync(externalDpId);

            if(externalDp == null)
            {
                throw new IdNotFoundException("entity not foun by key");
            }

            _externalDpRepository.Remove(externalDp);

            await _unitOfWork.CommitAsync();//Async 
        }
    }
}