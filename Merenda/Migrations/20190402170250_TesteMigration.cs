using Microsoft.EntityFrameworkCore.Migrations;

namespace Merenda.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
