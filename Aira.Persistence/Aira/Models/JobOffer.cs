﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Aira.Persistence.Aira.Models
{
    public partial class JobOffer
    {
        public Guid JobOfferId { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}