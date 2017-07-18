using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VolunteerSystem.Models;

namespace VolunteerSystem.Migrations
{
    [DbContext(typeof(VolunteerSystemContext))]
    partial class VolunteerSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolunteerSystem.Models.Volunteer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("cellNumber");

                    b.Property<string>("eduBackground");

                    b.Property<string>("emailAddress");

                    b.Property<string>("emergencyAddr");

                    b.Property<string>("emergencyEmail");

                    b.Property<string>("emergencyName");

                    b.Property<string>("emergencyPhone");

                    b.Property<string>("firstName");

                    b.Property<string>("homeNumber");

                    b.Property<bool>("isApproved");

                    b.Property<bool>("isLicenseOnFile");

                    b.Property<bool>("isSSCardOnFile");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("userName");

                    b.Property<string>("workNumber");

                    b.HasKey("ID");

                    b.ToTable("Volunteer");
                });
        }
    }
}
