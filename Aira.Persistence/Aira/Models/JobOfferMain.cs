﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Aira.Persistence.Aira.Models
{
    public partial class JobOfferMain
    {
        public Guid JobOfferId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string SalaryType { get; set; }
        public string SalaryCurrency { get; set; }
        public decimal? SalaryFrom { get; set; }
        public decimal? SalaryTo { get; set; }
        public string SalaryTime { get; set; }
        public string AddressCountry { get; set; }
        public string AddressCity { get; set; }
        public string AddressVoivodeship { get; set; }
        public string AddressStreet { get; set; }
        public string WorkModel { get; set; }
        public string ContractType { get; set; }
        public string WorkMode { get; set; }
        public string RecruitmentMode { get; set; }
        public byte? VacancyNumber { get; set; }
    }
}