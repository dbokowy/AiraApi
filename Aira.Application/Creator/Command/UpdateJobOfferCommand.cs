using MediatR;

namespace Aira.Domain.Business.Creator.Command
{
    public class UpdateJobOfferCommand : IRequest
    {
        public Guid JobOfferId { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyLogo { get; set; }
        public string SalaryType { get; set; }
        public decimal? SalaryFrom { get; set; }
        public decimal? SalaryTo { get; set; }
        public DateTime? SalaryTime { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCity { get; set; }
        public string LocationVoivodeship { get; set; }
        public string LocationDetails { get; set; }
        public string WorkingModel { get; set; }
        public string ContractType { get; set; }
        public string WorkingTime { get; set; }
        public string RecruitmentMode { get; set; }
        public int? VacancyNumber { get; set; }
    }
}