using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    ShipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.ShipID);
                });

            migrationBuilder.CreateTable(
                name: "Rope",
                columns: table => new
                {
                    RopeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tag = table.Column<int>(nullable: false),
                    Probability = table.Column<double>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    ShipID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rope", x => x.RopeID);
                    table.ForeignKey(
                        name: "FK_Rope_Ship_ShipID",
                        column: x => x.ShipID,
                        principalTable: "Ship",
                        principalColumn: "ShipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RawImage = table.Column<byte[]>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    RopeID = table.Column<int>(nullable: false),
                    ShipID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_Rope_RopeID",
                        column: x => x.RopeID,
                        principalTable: "Rope",
                        principalColumn: "RopeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_Ship_ShipID",
                        column: x => x.ShipID,
                        principalTable: "Ship",
                        principalColumn: "ShipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_RopeID",
                table: "Image",
                column: "RopeID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ShipID",
                table: "Image",
                column: "ShipID");

            migrationBuilder.CreateIndex(
                name: "IX_Rope_ShipID",
                table: "Rope",
                column: "ShipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Rope");

            migrationBuilder.DropTable(
                name: "Ship");
        }
    }
}
