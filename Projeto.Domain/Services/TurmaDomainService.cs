﻿using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;

namespace Projeto.Domain.Services
{
    public class TurmaDomainService : BaseDomainService<Turma>, ITurmaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TurmaDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.TurmaRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
