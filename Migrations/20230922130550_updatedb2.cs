using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCD_test.Migrations
{
    /// <inheritdoc />
    public partial class updatedb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee_Tbl");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department_Tbl");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee_Tbl",
                newName: "IX_Employee_Tbl_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_Tbl",
                table: "Employee_Tbl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department_Tbl",
                table: "Department_Tbl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tbl_Department_Tbl_DepartmentId",
                table: "Employee_Tbl",
                column: "DepartmentId",
                principalTable: "Department_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Tbl_Department_Tbl_DepartmentId",
                table: "Employee_Tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_Tbl",
                table: "Employee_Tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department_Tbl",
                table: "Department_Tbl");

            migrationBuilder.RenameTable(
                name: "Employee_Tbl",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Department_Tbl",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Tbl_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
