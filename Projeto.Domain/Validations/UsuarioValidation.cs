using FluentValidation;
using Projeto.Domain.Models;

namespace Projeto.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id do usuario obrigatorio.");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Nome do usuario obrigatorio.")
                .Length(6, 150).WithMessage("Nome de ter de 6 a 150 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("E-mail do usuario obrigatorio.")
                .EmailAddress().WithMessage("Endereco de e-mail invalido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Senha do usuario obrigatorio.")
                .Length(6, 20).WithMessage("Senha deve ter de 6 a 20 caracteres.");

            RuleFor(u => u.DataCriacao)
                .NotEmpty().WithMessage("Data de criacao do usuario obrigatorio.");
        }
    }
}
