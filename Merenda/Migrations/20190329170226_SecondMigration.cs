using Microsoft.EntityFrameworkCore.Migrations;

namespace Merenda.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Matricula",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
