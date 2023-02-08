using Microsoft.EntityFrameworkCore.Storage;

namespace Aira.Application.Creator.Uow.Interface
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransaction();
        Task Save();
        void Dispose();
    }
}