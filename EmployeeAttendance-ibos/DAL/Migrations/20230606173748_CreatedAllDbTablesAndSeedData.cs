using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAllDbTablesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPresent = table.Column<int>(type: "int", nullable: false),
                    IsAbsent = table.Column<int>(type: "int", nullable: false),
                    IsOffday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployeeAttendance_tblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblEmployee",
                columns: new[] { "Id", "Code", "Name", "Salary" },
                values: new object[,]
                {
                    { 502030, "EMP319", "Mehedi Hasan", 50000.0 },
                    { 502031, "EMP321", "Ashikur Rahman", 45000.0 },
                    { 502032, "EMP322", "Rakibul Islam", 52000.0 }
                });

            migrationBuilder.InsertData(
                table: "tblEmployeeAttendance",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, 0, 0, 1 },
                    { 2, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, 1, 0, 0 },
                    { 3, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, 0, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_Code",
                table: "tblEmployee",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeAttendance_EmployeeId",
                table: "tblEmployeeAttendance",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployeeAttendance");

            migrationBuilder.DropTable(
                name: "tblEmployee");
        }
    }
}
