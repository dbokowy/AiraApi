using Aira.Core.Repository;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferMainRepository : BaseRepository<JobOfferMain>, IJobOfferMainRepository
    {
        public JobOfferMainRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
