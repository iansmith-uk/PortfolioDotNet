using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioSite.Data.Migrations
{
    public partial class UpdatedInfoModelAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "uID",
                table: "InfoModels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "uID",
                table: "InfoModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
