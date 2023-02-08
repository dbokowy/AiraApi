using Aira.Domain.Business.Creator.Dto;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries
{
    public class GetJobOfferQuery : IRequest<JobOfferDto>
    {
        public Guid JobOfferId { get; set; }
    }
}
