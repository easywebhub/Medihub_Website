﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medihub.Backend.Api.Models
{
    public class CampaignDrugModel
    {
        public List<long> ListDrugId { get; set; }
        public int CampaignId { get; set; }
    }
}