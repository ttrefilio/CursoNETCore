using FluentValidation;
using Projeto.Domain.Models;
using Projeto.Domain.Validations.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Id do aluno obrigatório");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Nome do aluno obrigatório")
                .Length(6, 150).WithMessage("Nome deve ter de 6 a 150 caracteres.");

            RuleFor(a => a.Matricula)
                .NotEmpty().WithMessage("Matrícula do aluno obrigatório")
                .Length(6, 20).WithMessage("Matrícula deve ter de 6 a 20 caracteres.");

            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("Nome do aluno obrigatório")
                .Length(6, 150).WithMessage("Nome deve ter de 6 a 150 caracteres.")
                .Must(CpfValidation.IsValid).WithMessage("CPF inválido.");

            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("Data de nascimento do aluno obrigatória.")
                .Must(MaiorDeIdadeValidation.IsValid).WithMessage("Aluno deve ser maior de idade");
        }
    }
}
