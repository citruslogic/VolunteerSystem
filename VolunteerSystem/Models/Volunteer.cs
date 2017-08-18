﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VolunteerSystem.Models
{
    public class Volunteer
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        public string UserName {get; set; }

        public string Password { get; set; }

        
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }

        public ICollection<EducationBackground> Background { get; set; }

        public ICollection<CurrentLicense> Licenses { get; set; }

        public ICollection<Center> Centers { get; set; }

        public ICollection<InterestsSkill> InterestsSkills { get; set; }

        public ICollection<Availability> AvailableTimes { get; set; }

        public ICollection<EmergencyContact> EmergencyContacts { get; set; }

        public Boolean LicenseOnFile { get; set; }
        
        public Boolean SSCardOnFile { get; set; }

        public Boolean Approved { get; set; }

    }
}
