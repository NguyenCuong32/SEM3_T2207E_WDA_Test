using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_NguyenVanQuy.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_departmentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmenetId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "departmentId",
                table: "Employee",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_departmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employee",
                newName: "departmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_departmentId");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmenetId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Department",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_departmentId",
                table: "Employee",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }
    }
}
