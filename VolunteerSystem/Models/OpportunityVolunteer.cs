﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VolunteerSystem.Models
{
    public class OpportunityVolunteer
    {
        public int VolunteerID { get; set; }
        public int OpportunityID { get; set; }

        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }


    }
}
