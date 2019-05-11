using Microsoft.EntityFrameworkCore.Migrations;

namespace Merenda.Migrations
{
    public partial class NivelEmAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Alunos");
        }
    }
}
