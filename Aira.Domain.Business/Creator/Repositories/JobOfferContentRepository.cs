using Aira.Core.Repository;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferContentRepository : BaseRepository<JobOfferContent>, IJobOfferContentRepository
    {
        public JobOfferContentRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
