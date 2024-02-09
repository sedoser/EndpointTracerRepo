using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.DataAccess.Repositories;
using EndpointTracer.DataAccess.Uow;
using EndpointTracer.Model;

namespace EndpointTracer.Biz
{
    public class CertificateService : ICertificateService
    {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IRepository<Certificate> _certificateRepository;
      

      public CertificateService(IRepository<Certificate> certificateRepository, IUnitOfWork unitOfWork)
    {
        _certificateRepository = certificateRepository;
        _unitOfWork = unitOfWork;
    }

        public async Task AddAsync(Certificate certificate)
        {
            await _certificateRepository.AddAsync(certificate);
            

            //156454 
            await _unitOfWork.CommmitAsync();//bitane m fazla
        }

        public async Task<IEnumerable<Certificate>> GetAllAsync()
        {
             return await _certificateRepository.GetAllAsync();
        }

//async metotlar için CancellationToken kullanılabilir.
        public async Task<Certificate> GetByIdAsync(int id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
                if (certificate == null)
                {
                    //@todo:Custom bir exception sınıfı yazılacak. for ex: CustomException
                    throw new KeyNotFoundException($"A certificate with the ID {id} was not found.");
                }
                return certificate;
        }
            
        public void Remove(Certificate certificate)
        {
            _certificateRepository.Remove(certificate);
            _unitOfWork.Commit();//Async 
        }

        public async Task Update(Certificate certificate)
        {
            var existingCertificate = await _certificateRepository.GetByIdAsync(certificate.CertificateId);
            if (existingCertificate == null)
            {
                throw new KeyNotFoundException($"A certificate with the ID {certificate.CertificateId} was not found.");
            }
            _certificateRepository.Update(certificate);
            await _unitOfWork.CommmitAsync();
        }
    }
}