using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolaERP.Server.Migrations
{
    public partial class _20220402_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SyteLineUserCode",
                schema: "Config",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SyteLineUserCode",
                schema: "Config",
                table: "AppUser");
        }
    }
}
