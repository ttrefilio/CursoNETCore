﻿using MediatR;
using System;

namespace Projeto.Application.Commands.Alunos
{
    public class CreateAlunoCommand : IRequest
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
