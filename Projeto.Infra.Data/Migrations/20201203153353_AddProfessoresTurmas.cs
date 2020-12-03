using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class AddProfessoresTurmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmasAlunos",
                columns: table => new
                {
                    TurmaId = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmasAlunos", x => new { x.TurmaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_TurmasAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmasAlunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Email",
                table: "Professores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorId",
                table: "Turmas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmasAlunos_AlunoId",
                table: "TurmasAlunos",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmasAlunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
