using Aira.Core.Repository;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferRepository : BaseRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
