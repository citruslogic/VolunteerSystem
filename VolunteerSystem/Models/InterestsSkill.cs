using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSystem.Models
{
    public class InterestsSkill
    {
        public int InterestsSkillsID { get; set; }
        public int VolunteerID { get; set; }

        public List<string> InterestsSkills { get; set; }
    }
}
