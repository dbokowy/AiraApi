using Aira.Core.Repository;
using Aira.Core.Repository.Interface;
using Aira.Persistence.Aira;
using Aira.Persistence.Aira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aira.Application.Creator.Repositories
{
    public class JobOfferContentEducationRepository : BaseRepository<JobOfferContentEducation>, IJobOfferContentEducationRepository
    {
        public JobOfferContentEducationRepository(AiraContext _context) : base(_context)
        {
        }
    }
}
