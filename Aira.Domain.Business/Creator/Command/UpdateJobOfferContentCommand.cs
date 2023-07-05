using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferContentCommand : IRequest
    {
        public Guid JobOfferId { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public string Benefits { get; set; }
        public string Our_offer { get; set; }
        public string EducationLevel { get; set; }
        public string EducationStudiesName { get; set; }
        public string EducationStudiesStage { get; set; }
        public string CertificatesName { get; set; }
        public string CertificatesStage { get; set; }
        public string CertificatesQualification { get; set; }
        public string ExperiencePosition { get; set; }
        public string ExperienceField { get; set; }
        public string ExperienceTime { get; set; }
    }
}