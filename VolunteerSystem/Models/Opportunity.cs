using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace VolunteerSystem.Models
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public int VolunteerID { get; set; }

        [Display(Name = "Opportunity Name")]
        public string OpportunityName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Opportunity Date")]
        public DateTime OpportunityDate { get; set; }
        public string Description { get; set; }

    }
}
