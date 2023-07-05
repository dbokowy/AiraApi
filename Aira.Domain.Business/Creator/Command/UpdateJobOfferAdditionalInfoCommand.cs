using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferAdditionalInfoCommand : IRequest
    {
        public Guid JobOfferId { get; set; }
        public string DataProcessing { get; set; }
        public string MediumType { get; set; }
        public string CvFormat { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactInfo { get; set; }
    }
}