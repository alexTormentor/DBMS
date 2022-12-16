using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMech_v2.Migrations
{
    public partial class AddMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Meches",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Meches"
                );
        }
    }
}
