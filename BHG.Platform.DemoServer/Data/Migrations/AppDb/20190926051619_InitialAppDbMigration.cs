using Microsoft.EntityFrameworkCore.Migrations;

namespace BHG.Platform.DemoServer.Data.Migrations.AppDb
{
    public partial class InitialAppDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiuPengRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiuPengRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiuPengDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false),
                    LiuPengRegionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiuPengDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiuPengDistricts_LiuPengRegions_LiuPengRegionId",
                        column: x => x.LiuPengRegionId,
                        principalTable: "LiuPengRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiuPengLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false),
                    LiuPengDistrictId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false),
                    PhysicalId = table.Column<int>(type: "int(11)", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", nullable: true),
                    ManagerName = table.Column<string>(type: "varchar(120)", nullable: true),
                    ManagerPhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    ContactName = table.Column<string>(type: "varchar(120)", nullable: true),
                    ContactPhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Printer = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiuPengLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiuPengLocations_LiuPengDistricts_LiuPengDistrictId",
                        column: x => x.LiuPengDistrictId,
                        principalTable: "LiuPengDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiuPengDistricts_LiuPengRegionId",
                table: "LiuPengDistricts",
                column: "LiuPengRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LiuPengLocations_LiuPengDistrictId",
                table: "LiuPengLocations",
                column: "LiuPengDistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiuPengLocations");

            migrationBuilder.DropTable(
                name: "LiuPengDistricts");

            migrationBuilder.DropTable(
                name: "LiuPengRegions");
        }
    }
}
