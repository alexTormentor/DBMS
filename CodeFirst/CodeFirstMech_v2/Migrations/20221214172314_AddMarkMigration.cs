using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMech_v2.Migrations
{
    public partial class AddMarkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "MECH_NEW",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    serialID = table.Column<int>(nullable: true),
                    model = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MECH_NEW", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Armore = table.Column<string>(nullable: true),
                    Weapon = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SerialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meches", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "MECH_NEW");

            migrationBuilder.DropTable(
                name: "Meches");
        }
    }
}
