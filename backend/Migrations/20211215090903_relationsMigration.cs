using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class relationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_User_Medicid",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_User_Medicid",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_Medicid",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Medicid",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Medicid",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "Medicid",
                table: "Clinics");

            migrationBuilder.CreateTable(
                name: "ClinicMedic",
                columns: table => new
                {
                    clinicsid = table.Column<int>(type: "integer", nullable: false),
                    medicsid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicMedic", x => new { x.clinicsid, x.medicsid });
                    table.ForeignKey(
                        name: "FK_ClinicMedic_Clinics_clinicsid",
                        column: x => x.clinicsid,
                        principalTable: "Clinics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicMedic_User_medicsid",
                        column: x => x.medicsid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicSpecialization",
                columns: table => new
                {
                    medicsid = table.Column<int>(type: "integer", nullable: false),
                    specializationsid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicSpecialization", x => new { x.medicsid, x.specializationsid });
                    table.ForeignKey(
                        name: "FK_MedicSpecialization_Specializations_specializationsid",
                        column: x => x.specializationsid,
                        principalTable: "Specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicSpecialization_User_medicsid",
                        column: x => x.medicsid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicMedic_medicsid",
                table: "ClinicMedic",
                column: "medicsid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicSpecialization_specializationsid",
                table: "MedicSpecialization",
                column: "specializationsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicMedic");

            migrationBuilder.DropTable(
                name: "MedicSpecialization");

            migrationBuilder.AddColumn<int>(
                name: "Medicid",
                table: "Specializations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Medicid",
                table: "Clinics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Medicid",
                table: "Specializations",
                column: "Medicid");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Medicid",
                table: "Clinics",
                column: "Medicid");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_User_Medicid",
                table: "Clinics",
                column: "Medicid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_User_Medicid",
                table: "Specializations",
                column: "Medicid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
