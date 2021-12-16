using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace backend.Migrations
{
    public partial class medicRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_User_userid",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicMedic_User_medicsid",
                table: "ClinicMedic");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicSpecialization_User_medicsid",
                table: "MedicSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Clinics_clinicid",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_User_patientid",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_User_receptionistid",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_User_userid",
                table: "WorkingTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "insuranceId",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Receptionists");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "WorkingTimes",
                newName: "medicid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingTimes_userid",
                table: "WorkingTimes",
                newName: "IX_WorkingTimes_medicid");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Availabilities",
                newName: "medicid");

            migrationBuilder.RenameIndex(
                name: "IX_Availabilities_userid",
                table: "Availabilities",
                newName: "IX_Availabilities_medicid");

            migrationBuilder.RenameIndex(
                name: "IX_User_clinicid",
                table: "Receptionists",
                newName: "IX_Receptionists_clinicid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receptionists",
                table: "Receptionists",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Medics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    medicRole = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    PESEL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    insuranceId = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    PESEL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Medics_medicid",
                table: "Availabilities",
                column: "medicid",
                principalTable: "Medics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicMedic_Medics_medicsid",
                table: "ClinicMedic",
                column: "medicsid",
                principalTable: "Medics",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicSpecialization_Medics_medicsid",
                table: "MedicSpecialization",
                column: "medicsid",
                principalTable: "Medics",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Clinics_clinicid",
                table: "Receptionists",
                column: "clinicid",
                principalTable: "Clinics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_patientid",
                table: "Visits",
                column: "patientid",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Receptionists_receptionistid",
                table: "Visits",
                column: "receptionistid",
                principalTable: "Receptionists",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_Medics_medicid",
                table: "WorkingTimes",
                column: "medicid",
                principalTable: "Medics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Medics_medicid",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicMedic_Medics_medicsid",
                table: "ClinicMedic");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicSpecialization_Medics_medicsid",
                table: "MedicSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Clinics_clinicid",
                table: "Receptionists");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_patientid",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Receptionists_receptionistid",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_Medics_medicid",
                table: "WorkingTimes");

            migrationBuilder.DropTable(
                name: "Medics");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receptionists",
                table: "Receptionists");

            migrationBuilder.RenameTable(
                name: "Receptionists",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "medicid",
                table: "WorkingTimes",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingTimes_medicid",
                table: "WorkingTimes",
                newName: "IX_WorkingTimes_userid");

            migrationBuilder.RenameColumn(
                name: "medicid",
                table: "Availabilities",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_Availabilities_medicid",
                table: "Availabilities",
                newName: "IX_Availabilities_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Receptionists_clinicid",
                table: "User",
                newName: "IX_User_clinicid");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "insuranceId",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_User_userid",
                table: "Availabilities",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicMedic_User_medicsid",
                table: "ClinicMedic",
                column: "medicsid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicSpecialization_User_medicsid",
                table: "MedicSpecialization",
                column: "medicsid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Clinics_clinicid",
                table: "User",
                column: "clinicid",
                principalTable: "Clinics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_User_patientid",
                table: "Visits",
                column: "patientid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_User_receptionistid",
                table: "Visits",
                column: "receptionistid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_User_userid",
                table: "WorkingTimes",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
