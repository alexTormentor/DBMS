using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMech_v2.Migrations
{
    public partial class AddForOt4et : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForOt4et",
                table: "Meches",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForOt4et",
                table: "Meches"
                );
        }
    }
}
