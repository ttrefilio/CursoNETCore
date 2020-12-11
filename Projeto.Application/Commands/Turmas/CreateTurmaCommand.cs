using System;

namespace Projeto.Application.Commands.Turmas
{
    public class CreateTurmaCommand
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public string ProfessorId { get; set; }
    }
}
