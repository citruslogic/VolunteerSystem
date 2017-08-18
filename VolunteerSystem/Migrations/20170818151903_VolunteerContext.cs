using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VolunteerSystem.Migrations
{
    public partial class VolunteerContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LicenseOnFile = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    SSCardOnFile = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    AvailabilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableEndTime = table.Column<DateTime>(nullable: false),
                    AvailableStartTime = table.Column<DateTime>(nullable: false),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.AvailabilityID);
                    table.ForeignKey(
                        name: "FK_Availability_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    CenterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CenterAddr = table.Column<string>(nullable: true),
                    CenterName = table.Column<string>(nullable: true),
                    CenterPhone = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.CenterID);
                    table.ForeignKey(
                        name: "FK_Center_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentLicense",
                columns: table => new
                {
                    CurrentLicenseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    License = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentLicense", x => x.CurrentLicenseID);
                    table.ForeignKey(
                        name: "FK_CurrentLicense_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationBackground",
                columns: table => new
                {
                    EducationBackgroundID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Background = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationBackground", x => x.EducationBackgroundID);
                    table.ForeignKey(
                        name: "FK_EducationBackground_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    EmergencyContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.EmergencyContactID);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestsSkill",
                columns: table => new
                {
                    InterestsSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InterestsSkills = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsSkill", x => x.InterestsSkillID);
                    table.ForeignKey(
                        name: "FK_InterestsSkill_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_VolunteerID",
                table: "Availability",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_Center_VolunteerID",
                table: "Center",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentLicense_VolunteerID",
                table: "CurrentLicense",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationBackground_VolunteerID",
                table: "EducationBackground",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_VolunteerID",
                table: "EmergencyContact",
                column: "VolunteerID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsSkill_VolunteerID",
                table: "InterestsSkill",
                column: "VolunteerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "CurrentLicense");

            migrationBuilder.DropTable(
                name: "EducationBackground");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "InterestsSkill");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
