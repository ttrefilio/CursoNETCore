using System;
using System.Collections.Generic;

namespace Projeto.Domain.DTOs
{
    public class TurmaDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }

        #region Relacionamentos
        public ProfessorDTO Professor { get; set; }
        public List<AlunoDTO> Alunos { get; set; }
        #endregion
    }
}
