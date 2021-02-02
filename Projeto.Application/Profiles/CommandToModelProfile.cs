using AutoMapper;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Commands.Usuarios;
using Projeto.Domain.Models;
using System;

namespace Projeto.Application.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            #region Usuarios

            CreateMap<CreateUsuarioCommand, Usuario>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.DataCriacao = DateTime.Now;
                });

            #endregion

            #region Alunos

            CreateMap<CreateAlunoCommand, Aluno>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<UpdateAlunoCommand, Aluno>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            CreateMap<DeleteAlunoCommand, Aluno>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));
            #endregion

            #region Professores

            CreateMap<CreateProfessorCommand, Professor>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<UpdateProfessorCommand, Professor>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));

            CreateMap<DeleteProfessorCommand, Professor>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));
            #endregion

            #region Turmas

            CreateMap<CreateTurmaCommand, Turma>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.ProfessorId = Guid.Parse(src.ProfessorId);
                });

            CreateMap<UpdateTurmaCommand, Turma>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.Parse(src.Id);
                    dest.ProfessorId = Guid.Parse(src.ProfessorId);
                });

            CreateMap<DeleteTurmaCommand, Turma>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));
            #endregion
        }
    }
}
