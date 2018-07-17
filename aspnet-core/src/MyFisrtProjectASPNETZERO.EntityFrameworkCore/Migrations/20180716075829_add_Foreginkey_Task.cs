using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFisrtProjectASPNETZERO.Migrations
{
    public partial class add_Foreginkey_Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employee_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employee_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Tasks");
        }
    }
}
