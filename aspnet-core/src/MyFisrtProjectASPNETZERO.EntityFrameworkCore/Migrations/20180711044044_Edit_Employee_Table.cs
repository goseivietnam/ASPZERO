using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFisrtProjectASPNETZERO.Migrations
{
    public partial class Edit_Employee_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Employee");
        }
    }
}
