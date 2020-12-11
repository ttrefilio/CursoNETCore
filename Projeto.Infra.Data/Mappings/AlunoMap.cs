using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;

namespace Projeto.Infra.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Matricula)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(a => a.DataNascimento)
                .IsRequired();
        }
    }
}
