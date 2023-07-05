using Aira.Domain.Business.Creator.Dto;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries
{
    public class GetJobOfferContentQuery : IRequest<JobOfferContentDto>
    {
        public Guid JobOfferId { get; set; }
    }
}
