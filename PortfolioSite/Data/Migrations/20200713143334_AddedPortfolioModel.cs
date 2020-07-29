using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioSite.Data.Migrations
{
    public partial class AddedPortfolioModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uID = table.Column<string>(nullable: false),
                    image = table.Column<byte[]>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    testingURL = table.Column<string>(nullable: true),
                    codeURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioModels", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioModels");
        }
    }
}
