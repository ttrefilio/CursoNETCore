using FluentValidation;
using Projeto.Domain.Models;

namespace Projeto.Domain.Validations
{
    public class ProfessorValidation : AbstractValidator<Professor>
    {
        public ProfessorValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id do professor obrigatório.");

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome do professor obrigatório.")
                .Length(6, 150).WithMessage("Nome deve ter de 6 a 150 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("E-mail do professor obrigatório.")
                .EmailAddress().WithMessage("Endereço de e-mail inválido.");
        }
    }
}
