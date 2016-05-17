using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(f => f.FuncionarioId);

            HasRequired(f => f.Pessoa)
                .WithMany()
                .HasForeignKey(f => f.PessoaId);

            HasRequired(f => f.PessoaJuridica)
                .WithMany(p => p.FuncionarioList)
                .HasForeignKey(f => f.PessoaJuridicaId);

            ToTable("Funcionarios");
        }
    }
}
