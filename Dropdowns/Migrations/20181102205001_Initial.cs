using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dropdowns.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dropdowns");

            migrationBuilder.CreateTable(
                name: "Continent",
                schema: "Dropdowns",
                columns: table => new
                {
                    ContinentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContinentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ContinentID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Dropdowns",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryName = table.Column<string>(nullable: true),
                    ContinentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Continent_ContinentID",
                        column: x => x.ContinentID,
                        principalSchema: "Dropdowns",
                        principalTable: "Continent",
                        principalColumn: "ContinentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corporation",
                schema: "Dropdowns",
                columns: table => new
                {
                    CorporationID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CorporationName = table.Column<string>(nullable: true),
                    ContinentID = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporation", x => x.CorporationID);
                    table.ForeignKey(
                        name: "FK_Corporation_Continent_ContinentID",
                        column: x => x.ContinentID,
                        principalSchema: "Dropdowns",
                        principalTable: "Continent",
                        principalColumn: "ContinentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corporation_Country_CountryID",
                        column: x => x.CountryID,
                        principalSchema: "Dropdowns",
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corporation_ContinentID",
                schema: "Dropdowns",
                table: "Corporation",
                column: "ContinentID");

            migrationBuilder.CreateIndex(
                name: "IX_Corporation_CountryID",
                schema: "Dropdowns",
                table: "Corporation",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentID",
                schema: "Dropdowns",
                table: "Country",
                column: "ContinentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corporation",
                schema: "Dropdowns");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Dropdowns");

            migrationBuilder.DropTable(
                name: "Continent",
                schema: "Dropdowns");
        }
    }
}
