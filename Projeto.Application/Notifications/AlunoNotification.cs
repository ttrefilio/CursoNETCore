using MediatR;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Notifications
{
    //Classe contendo informacoes do Aluno quando uma acao for realizada pelo MediatR
    public class AlunoNotification : INotification
    {
        public Aluno Aluno { get; set; }
        public ActionNotification Action { get; set; }
    }
}
