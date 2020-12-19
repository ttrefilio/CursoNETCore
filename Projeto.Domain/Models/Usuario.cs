using System;

namespace Projeto.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        public Usuario()
        {

        }

        public Usuario(Guid id, string nome, string email, string senha, DateTime dataCriacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCriacao = dataCriacao;
        }
    }
}
