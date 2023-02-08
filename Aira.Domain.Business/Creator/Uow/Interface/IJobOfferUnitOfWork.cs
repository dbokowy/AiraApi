using Aira.Application.Creator.Repositories;
using Aira.Persistence.Aira;
using Microsoft.EntityFrameworkCore.Storage;

namespace Aira.Application.Creator.Uow.Interface
{
    public interface IJobOfferUnitOfWork : IUnitOfWork
    {
        IJobOfferRepository JobOfferRepository { get; }
        IJobOfferMainRepository JobOfferMainRepository { get; }
        IJobOfferContentRepository JobOfferContentRepository { get; }
        IJobOfferContentEducationRepository JobOfferContentEducationRepository { get; }
        IJobOfferAdditionalInfoRepository JobOfferAdditionalInfoRepository { get; }

        Task<IDbContextTransaction> BeginTransaction();
        Task Save();
        Task Commit();
        void Dispose();
    }
}
