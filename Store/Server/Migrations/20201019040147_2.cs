using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Server.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClientServer",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JPushId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClientServer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JPushId",
                table: "AspNetUsers");
        }
    }
}
