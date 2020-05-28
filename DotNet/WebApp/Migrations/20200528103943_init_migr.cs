using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class init_migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currensies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(maxLength: 3, nullable: false),
                    Buy = table.Column<decimal>(nullable: false),
                    Sell = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currensies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    ToCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    BuyAmount = table.Column<decimal>(nullable: false),
                    SellAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currensies");

            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
