using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;

namespace Projeto.Infra.Data.Mappings
{
    public class TurmaAlunoMap : IEntityTypeConfiguration<TurmaAluno>
    {
        public void Configure(EntityTypeBuilder<TurmaAluno> builder)
        {
            builder.HasKey(t => new { t.TurmaId, t.AlunoId });

            builder.HasOne(ta => ta.Turma)
                .WithMany(t => t.Alunos)
                .HasForeignKey(ta => ta.TurmaId);

            builder.HasOne(ta => ta.Aluno)
                .WithMany(a => a.Turmas)
                .HasForeignKey(t => t.AlunoId);
        }
    }
}
