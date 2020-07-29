using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioSite.Data.Migrations
{
    public partial class UpdatedInfoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "uID",
                table: "InfoModels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uID",
                table: "InfoModels");
        }
    }
}
