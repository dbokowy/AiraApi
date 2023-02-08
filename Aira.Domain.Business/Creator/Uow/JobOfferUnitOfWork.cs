using Aira.Application.Creator.Repositories;
using Aira.Application.Creator.Uow.Interface;
using Aira.Persistence.Aira;
using Microsoft.EntityFrameworkCore.Storage;

namespace Aira.Application.Creator.Uow
{
    public class JobOfferUnitOfWork : IDisposable, IJobOfferUnitOfWork
    {
        private readonly AiraContext _context;
        public IJobOfferRepository JobOfferRepository { get; }
        public IJobOfferMainRepository JobOfferMainRepository { get; }
        public IJobOfferContentRepository JobOfferContentRepository { get; }
        public IJobOfferContentEducationRepository JobOfferContentEducationRepository { get; }
        public IJobOfferAdditionalInfoRepository JobOfferAdditionalInfoRepository { get; }

        public JobOfferUnitOfWork(AiraContext context, 
            IJobOfferRepository jobOfferRepository, 
            IJobOfferMainRepository jobOfferMainRepository, 
            IJobOfferContentRepository jobOfferContentRepository, 
            IJobOfferContentEducationRepository jobOfferContentEducationRepository, 
            IJobOfferAdditionalInfoRepository jobOfferAdditionalInfoRepository)
        {
            _context = context;
            JobOfferRepository = jobOfferRepository;
            JobOfferMainRepository = jobOfferMainRepository;
            JobOfferContentRepository = jobOfferContentRepository;
            JobOfferContentEducationRepository = jobOfferContentEducationRepository;
            JobOfferAdditionalInfoRepository = jobOfferAdditionalInfoRepository;
        }

        public async Task<IDbContextTransaction> BeginTransaction() => await _context.Database.BeginTransactionAsync();
        public async Task Save() => await _context.SaveChangesAsync();
        public async Task Commit() => await _context.Database.CommitTransactionAsync();
        public void Dispose() => _context.Dispose();
    }
}
