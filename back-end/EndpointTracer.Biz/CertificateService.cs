using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Biz;
using EndpointTracer.DataAccess.Repositories;
using EndpointTracer.Model;

namespace EndpointTracer.Biz
{
    public class CertificateService : ICertificateService
    {
      private readonly IRepository<Certificate> _certificateRepository;

      public CertificateService(IRepository<Certificate> certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

        public async Task AddAsync(Certificate certificate)
        {
            await _certificateRepository.AddAsync(certificate);
        }

        public async Task<IEnumerable<Certificate>> GetAllAsync()
        {
             return await _certificateRepository.GetAllAsync();
        }

        public async Task<Certificate> GetByIdAsync(int id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
                if (certificate == null)
                {
                    throw new KeyNotFoundException($"A certificate with the ID {id} was not found.");
                }
                return certificate;
        }

        public void Remove(Certificate certificate)
        {
            _certificateRepository.Remove(certificate);
        }

        public async Task Update(Certificate certificate)
        {
            var existingCertificate = await _certificateRepository.GetByIdAsync(certificate.CertificateId);
            if (existingCertificate == null)
            {
                throw new KeyNotFoundException($"A certificate with the ID {certificate.CertificateId} was not found.");
            }
            _certificateRepository.Update(certificate);
        }
    }
}