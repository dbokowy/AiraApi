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
        public string CompanyLogo { get; set; } //TODO :: do usuniecia
        public string SalaryType { get; set; }
        public decimal? SalaryFrom { get; set; }
        public decimal? SalaryTo { get; set; }
        public string SalaryTime { get; set; }
        public string SalaryCurrency { get; set; }
        public string AddressCountry { get; set; } 
        public string AddressCity { get; set; } 
        //public string AddressVoivodeship { get; set; } // TODO dodac na froncie
        public string AddressStreet { get; set; }
        public string WorkModel { get; set; }
        public string ContractType { get; set; }
        public string WorkMode { get; set; }
        public string RecruitmentMode { get; set; }
        public int? VacancyNumber { get; set; }
    }
}