using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VolunteerSystem.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    OpportunityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    OpportunityDate = table.Column<DateTime>(nullable: false),
                    OpportunityName = table.Column<string>(nullable: true),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.OpportunityID);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityVolunteer",
                columns: table => new
                {
                    OpportunityID = table.Column<int>(nullable: false),
                    VolunteerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityVolunteer", x => new { x.OpportunityID, x.VolunteerID });
                    table.ForeignKey(
                        name: "FK_OpportunityVolunteer_Opportunity_OpportunityID",
                        column: x => x.OpportunityID,
                        principalTable: "Opportunity",
                        principalColumn: "OpportunityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpportunityVolunteer_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityVolunteer_VolunteerID",
                table: "OpportunityVolunteer",
                column: "VolunteerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpportunityVolunteer");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteer",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteer",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
