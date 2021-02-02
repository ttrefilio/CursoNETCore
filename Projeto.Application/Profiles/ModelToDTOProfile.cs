using AutoMapper;
using Projeto.Domain.DTOs;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Profiles
{
    class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            #region Alunos

            CreateMap<Aluno, AlunoDTO>();

            #endregion

            #region Professores

            CreateMap<Professor, ProfessorDTO>();

            #endregion

            #region Turmas

            CreateMap<Turma, TurmaDTO>();

            #endregion
        }
    }
}
