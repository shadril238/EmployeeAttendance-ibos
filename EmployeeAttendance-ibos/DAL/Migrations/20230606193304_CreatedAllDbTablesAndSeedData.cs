using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAllDbTablesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendance_Employee_EmployeeId",
                table: "EmployeeAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAttendance",
                table: "EmployeeAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeAttendance",
                newName: "EmployeeAttendances");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAttendance_EmployeeId",
                table: "EmployeeAttendances",
                newName: "IX_EmployeeAttendances_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Code",
                table: "Employees",
                newName: "IX_Employees_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttendances_Employees_EmployeeId",
                table: "EmployeeAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAttendances",
                table: "EmployeeAttendances");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeAttendances",
                newName: "EmployeeAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Code",
                table: "Employee",
                newName: "IX_Employee_Code");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendance",
                newName: "IX_EmployeeAttendance_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAttendance",
                table: "EmployeeAttendance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttendance_Employee_EmployeeId",
                table: "EmployeeAttendance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
