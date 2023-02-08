using Aira.Core.Repository;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferAdditionalInfoRepository : BaseRepository<JobOfferAdditionalInfo>, IJobOfferAdditionalInfoRepository
    {
        public JobOfferAdditionalInfoRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
