using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backendcCTRL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHealthStatsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalHealthStats",
                columns: table => new
                {
                    StatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Region = table.Column<string>(type: "text", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalHealthStats", x => x.StatID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    patientid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    fullname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    idnumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UserID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.patientid);
                    table.ForeignKey(
                        name: "FK_Patient_User_UserID1",
                        column: x => x.UserID1,
                        principalTable: "User",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "FK_Patient_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderID);
                    table.ForeignKey(
                        name: "FK_Provider_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthStats",
                columns: table => new
                {
                    StatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_HealthStats_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "patientid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthStats_Patient_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "Patient",
                        principalColumn: "patientid");
                });

            migrationBuilder.CreateTable(
                name: "SymptomsLog",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    Symptoms = table.Column<string>(type: "text", nullable: false),
                    AIResponse = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomsLog", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_SymptomsLog_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "patientid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    appointmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PatientID1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.appointmentid);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientID1",
                        column: x => x.PatientID1,
                        principalTable: "Patient",
                        principalColumn: "patientid");
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
                        principalColumn: "patientid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Provider_Provider",
                        column: x => x.Provider,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    ProviderID = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    IDNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_patientid",
                table: "Appointment",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID1",
                table: "Appointment",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Provider",
                table: "Appointment",
                column: "Provider");

            migrationBuilder.CreateIndex(
                name: "IX_HealthStats_PatientID",
                table: "HealthStats",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_HealthStats_PatientID1",
                table: "HealthStats",
                column: "PatientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_userid",
                table: "Patient",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserID1",
                table: "Patient",
                column: "UserID1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_UserID",
                table: "Provider",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ProviderID",
                table: "Staff",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserID",
                table: "Staff",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomsLog_PatientID",
                table: "SymptomsLog",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "GlobalHealthStats");

            migrationBuilder.DropTable(
                name: "HealthStats");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "SymptomsLog");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
