using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace backend.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    PESEL = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    insuranceId = table.Column<string>(type: "text", nullable: true),
                    clinicid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Availabilities_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    Medicid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Specializations_User_Medicid",
                        column: x => x.Medicid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    menager_id = table.Column<string>(type: "text", nullable: false),
                    specializationid = table.Column<int>(type: "integer", nullable: true),
                    Medicid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clinics_Specializations_specializationid",
                        column: x => x.specializationid,
                        principalTable: "Specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clinics_User_Medicid",
                        column: x => x.Medicid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    clinicid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.id);
                    table.ForeignKey(
                        name: "FK_WorkingTimes_Clinics_clinicid",
                        column: x => x.clinicid,
                        principalTable: "Clinics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkingTimes_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    workingTimeid = table.Column<int>(type: "integer", nullable: true),
                    patientid = table.Column<int>(type: "integer", nullable: true),
                    receptionistid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.id);
                    table.ForeignKey(
                        name: "FK_Visits_User_patientid",
                        column: x => x.patientid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_User_receptionistid",
                        column: x => x.receptionistid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_WorkingTimes_workingTimeid",
                        column: x => x.workingTimeid,
                        principalTable: "WorkingTimes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_userid",
                table: "Availabilities",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Medicid",
                table: "Clinics",
                column: "Medicid");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_specializationid",
                table: "Clinics",
                column: "specializationid");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Medicid",
                table: "Specializations",
                column: "Medicid");

            migrationBuilder.CreateIndex(
                name: "IX_User_clinicid",
                table: "User",
                column: "clinicid");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_patientid",
                table: "Visits",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_receptionistid",
                table: "Visits",
                column: "receptionistid");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_workingTimeid",
                table: "Visits",
                column: "workingTimeid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_clinicid",
                table: "WorkingTimes",
                column: "clinicid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_userid",
                table: "WorkingTimes",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Clinics_clinicid",
                table: "User",
                column: "clinicid",
                principalTable: "Clinics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_User_Medicid",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_User_Medicid",
                table: "Specializations");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
