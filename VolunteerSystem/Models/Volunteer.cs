using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VolunteerSystem.Models
{
    public class Volunteer
    {
       

        public int ID { get; set; }
        public int StatusID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]



        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string UserName { get; set; }

        public string Password { get; set; }


        public string Address { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        public string Email { get; set; }

        public ICollection<EducationBackground> Background { get; set; }

        public ICollection<CurrentLicense> Licenses { get; set; }

        public ICollection<Center> Centers { get; set; }

        [Display(Name = "Interests and Skills")]
        public ICollection<InterestsSkill> InterestsSkills { get; set; }

        [Display(Name = "Available Times")]
        public ICollection<Availability> AvailableTimes { get; set; }

        [Display(Name = "Emergency Contacts")]
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }

        [Display(Name = "License On File")]
        public Boolean LicenseOnFile { get; set; }

        [Display(Name = "SS Card On File")]
        public Boolean SSCardOnFile { get; set; }


        [Display(Name = "Status")]
        public Status Status { get; set; }

        

        

    }
}
