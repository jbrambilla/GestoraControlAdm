using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(f => f.PessoaId);

            HasRequired(f => f.Empresa)
                .WithMany(e => e.FuncionarioList)
                .HasForeignKey(f => f.EmpresaId);

            ToTable("Funcionarios");
        }
    }
}
