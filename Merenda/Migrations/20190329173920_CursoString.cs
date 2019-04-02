using Microsoft.EntityFrameworkCore.Migrations;

namespace Merenda.Migrations
{
    public partial class CursoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Alunos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "Alunos",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
