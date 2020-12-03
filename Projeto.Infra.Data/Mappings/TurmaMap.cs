using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;

namespace Projeto.Infra.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(t => t.DataInicio)
                .IsRequired();

            builder.HasOne(t => t.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.ProfessorId);
        }
    }
}
