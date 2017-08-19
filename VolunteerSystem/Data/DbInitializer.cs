using System;
using System.Collections.Generic;
using System.Linq;
using VolunteerSystem.Models;

namespace VolunteerSystem.Data
{
    public static class DbInitializer
    {

        public static void Initialize(VolunteerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any volunteers.
            if (context.Volunteers.Any())
                return;

            var volunteers = new Volunteer[]
            {
                new Volunteer{FirstName="Carson", LastName="Timothy", Address="101 Dundee Dr.", UserName="TCarson",
                    Password="whatever1", HomePhone="544-5440", CellPhone="444-0550", WorkPhone="100-2222",
                   Email="TCarson@imail.com", Status=Status.Approved},

                new Volunteer{FirstName="Fred", LastName="Taylor", Address="2011 Bent Oak Dr.", UserName="FTaylor",
                    Password="SomePass4U", HomePhone="555-5555", CellPhone="444-4444", WorkPhone="111-1111",
                    Email="FTaylor@noemail.com", Status=Status.Pending}
            };

            foreach (Volunteer v in volunteers)
            {
                context.Volunteers.Add(v);
            }
            context.SaveChanges();

            var opportunities = new Opportunity[]
            {
                new Opportunity{
                    Description ="A new community outreach activity.",
                    OpportunityName ="Community Outreach",
                    OpportunityDate =DateTime.Parse("2005-09-01")}

                
            };

            foreach (Opportunity o in opportunities)
            {
                context.Opportunities.Add(o);
            }
            context.SaveChanges();


            var opportunityVolunteers = new OpportunityVolunteer[]
            {
                new OpportunityVolunteer { OpportunityID = opportunities.Single(o => o.OpportunityName == "Community Outreach" ).OpportunityID,
                        VolunteerID = volunteers.Single(v => v.LastName == "Timothy").ID}
            };

            foreach (OpportunityVolunteer ov in opportunityVolunteers)
            {
                context.OpportunityVolunteers.Add(ov);
            }
            context.SaveChanges();

            var availabilities = new Availability[]
            {
                new Availability{VolunteerID=1, AvailableStartTime=DateTime.Parse("10:45 AM"),
                    AvailableEndTime=DateTime.Parse("5:30 PM")},

                new Availability{VolunteerID=2, AvailableStartTime=DateTime.Parse("11:00AM"),
                    AvailableEndTime=DateTime.Parse("6:00PM")}
            };

            foreach (Availability a in availabilities)
            {
                context.Availabilities.Add(a);
            }

            context.SaveChanges();

            var centers = new Center[]
            {
                new Center{CenterName="Unknown Center Name", CenterAddr="2507 Deer Run Pkwy.",
                CenterPhone="707-7000", VolunteerID=1 }
            };

            foreach (Center c in centers)
            {
                context.Centers.Add(c);
            }
            context.SaveChanges();

            var licenses = new CurrentLicense[]
            {
                new CurrentLicense{VolunteerID=1, License=""},
                new CurrentLicense{VolunteerID=2, License="ALicense"}
            };

            foreach (CurrentLicense l in licenses)
            {
                context.CurrentLicenses.Add(l);
            }
            context.SaveChanges();

            var education = new EducationBackground[]
            {
                new EducationBackground{VolunteerID=1, Background="BA Social Services" }

            };

            foreach (EducationBackground e in education)
            {
                context.EducationBackground.Add(e);
            }
            context.SaveChanges();

            var contacts = new EmergencyContact[]
            {
                new EmergencyContact{VolunteerID=1, Address="1704 Whispering Forest Dr.", FirstName="Fred", LastName="Jackson", PhoneNumber="904-555-5555" }
            };

            foreach (EmergencyContact ec in contacts)
            {
                context.EmergencyContacts.Add(ec);
            }
            context.SaveChanges();

            var interests = new InterestsSkill[]
            {
                new InterestsSkill{VolunteerID=1, InterestsSkills="Microsoft Excel, Skiing"}, 
                new InterestsSkill{VolunteerID=1, InterestsSkills="MS Access, Boating"}
            };

            foreach (InterestsSkill s in interests)
            {
                context.InterestsSkills.Add(s);
            }
            context.SaveChanges();

        }
    }
}
