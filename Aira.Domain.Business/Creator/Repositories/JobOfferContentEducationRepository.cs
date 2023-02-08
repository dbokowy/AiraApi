using Aira.Core.Repository;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferContentEducationRepository : BaseRepository<JobOfferContentEducation>, IJobOfferContentEducationRepository
    {
        public JobOfferContentEducationRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
