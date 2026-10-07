using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiREDDE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNC = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CommercialName = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    PaymentScheme = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    EconomicActivity = table.Column<string>(nullable: false),
                    GubernamentalBranch = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
