using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agendator.Migrations
{
    public partial class AgendatorModelsagendatorContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "main");

            migrationBuilder.CreateSequence<int>(
                name: "Client_ID_seq");

            migrationBuilder.CreateSequence<int>(
                name: "Employee_ID_seq");

            migrationBuilder.CreateSequence<int>(
                name: "Role_ID_seq");

            migrationBuilder.CreateSequence<int>(
                name: "Schedule_ID_seq");

            migrationBuilder.CreateSequence<int>(
                name: "Specialty_ID_seq");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "main",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false, defaultValueSql: "nextval('main.\"Role_ID_seq\"'::regclass)"),
                    Description = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "main",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false, defaultValueSql: "nextval('main.\"Schedule_ID_seq\"'::regclass)"),
                    DoctorID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    AppointmentStartTime = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    ExpectedPrice = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Canceled = table.Column<bool>(nullable: false),
                    CanceledReason = table.Column<string>(type: "character varying", nullable: false),
                    AppointmentEndTime = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    appointmentdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                schema: "main",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false, defaultValueSql: "nextval('main.\"Specialty_ID_seq\"'::regclass)"),
                    Description = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "main",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false, defaultValueSql: "nextval('main.\"Client_ID_seq\"'::regclass)"),
                    Email = table.Column<string>(type: "character varying", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Password = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Client", x => new { x.ID, x.Email });
                    table.ForeignKey(
                        name: "fk_Client_Role",
                        column: x => x.Role,
                        principalSchema: "main",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "main",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false, defaultValueSql: "nextval('main.\"Employee_ID_seq\"'::regclass)"),
                    Email = table.Column<string>(type: "character varying", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Password = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(type: "character varying", nullable: false),
                    Specialty = table.Column<int>(nullable: false),
                    AppointmentTime = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    StartWorkTime = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    EndWorkTime = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    AppointmentValue = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Employee", x => new { x.ID, x.Email });
                    table.ForeignKey(
                        name: "fk_Employee_Role",
                        column: x => x.Role,
                        principalSchema: "main",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Employee_Specialty",
                        column: x => x.Specialty,
                        principalSchema: "main",
                        principalTable: "Specialty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "main",
                table: "Role",
                columns: new[] { "ID", "Description" },
                values: new object[] { 1, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Role",
                schema: "main",
                table: "Client",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Role",
                schema: "main",
                table: "Employee",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Specialty",
                schema: "main",
                table: "Employee",
                column: "Specialty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "main");

            migrationBuilder.DropTable(
                name: "Specialty",
                schema: "main");

            migrationBuilder.DropSequence(
                name: "Client_ID_seq");

            migrationBuilder.DropSequence(
                name: "Employee_ID_seq");

            migrationBuilder.DropSequence(
                name: "Role_ID_seq");

            migrationBuilder.DropSequence(
                name: "Schedule_ID_seq");

            migrationBuilder.DropSequence(
                name: "Specialty_ID_seq");
        }
    }
}
