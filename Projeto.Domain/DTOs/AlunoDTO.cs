using System;

namespace Projeto.Domain.DTOs
{
    public class AlunoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
