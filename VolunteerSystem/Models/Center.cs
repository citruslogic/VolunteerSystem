using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class Center
    {
        public int CenterID { get; set; }
        public int VolunteerID { get; set; }
        public string CenterName { get; set; }
        public string CenterAddr { get; set; }
        public string CenterPhone { get; set; }
        
    }
}
