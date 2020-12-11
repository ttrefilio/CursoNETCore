using System;

namespace Projeto.Application.Commands.Turmas
{
    public class UpdateTurmaCommand
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public string ProfessorId { get; set; }
    }
}
