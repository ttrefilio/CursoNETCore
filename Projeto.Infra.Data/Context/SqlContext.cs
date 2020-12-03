using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaAluno> TurmasAlunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());

            //Adicionar indices na tabela
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasIndex(a => a.Cpf).IsUnique();
                entity.HasIndex(a => a.Matricula).IsUnique();
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasIndex(p => p.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
