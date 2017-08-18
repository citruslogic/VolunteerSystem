using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public int VolunteerID { get; set; }

        public string OpportunityName { get; set; }
        public DateTime OpportunityDate { get; set; }
        public string Description { get; set; }

    }
}
