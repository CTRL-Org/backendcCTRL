using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backendcCTRL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_user",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_user", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patientid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    fullname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    idnumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.patientid);
                    table.ForeignKey(
                        name: "FK_patient_app_user_UserID1",
                        column: x => x.UserID1,
                        principalTable: "app_user",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "FK_patient_app_user_userid",
                        column: x => x.userid,
                        principalTable: "app_user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    appointmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PatientID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.appointmentid);
                    table.ForeignKey(
                        name: "FK_appointment_patient_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "patient",
                        principalColumn: "patientid");
                    table.ForeignKey(
                        name: "FK_appointment_patient_patientid",
                        column: x => x.patientid,
                        principalTable: "patient",
                        principalColumn: "patientid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "healthstats",
                columns: table => new
                {
                    statid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<decimal>(type: "numeric", nullable: true),
                    weight = table.Column<decimal>(type: "numeric", nullable: true),
                    bloodtype = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    allergies = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    lastupdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthstats", x => x.statid);
                    table.ForeignKey(
                        name: "FK_healthstats_patient_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "patient",
                        principalColumn: "patientid");
                    table.ForeignKey(
                        name: "FK_healthstats_patient_patientid",
                        column: x => x.patientid,
                        principalTable: "patient",
                        principalColumn: "patientid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patientid",
                table: "appointment",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PatientID1",
                table: "appointment",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_healthstats_patientid",
                table: "healthstats",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_healthstats_PatientID1",
                table: "healthstats",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_patient_userid",
                table: "patient",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_UserID1",
                table: "patient",
                column: "UserID1",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "healthstats");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "app_user");
        }
    }
}
