using Aira.Domain.Business.Creator.Dto;
using MediatR;

namespace Aira.Domain.Business.Creator.Queries
{
    public class GetJobOfferListQuery : IRequest<List<JobOfferDto>>
    {

    }
}
