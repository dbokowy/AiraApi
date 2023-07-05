using Aira.Domain.Business.Creator.Dto;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries
{
    public class GetJobOfferAdditionalInfoQuery : IRequest<JobOfferAdditionalInfoDto>
    {
        public Guid JobOfferId { get; set; }
    }
}
