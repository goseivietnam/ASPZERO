using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFisrtProjectASPNETZERO.Migrations
{
    public partial class Edit_Employee_Table_ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
