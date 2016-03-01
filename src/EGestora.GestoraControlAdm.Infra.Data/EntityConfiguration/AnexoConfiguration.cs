using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class AnexoConfiguration : EntityTypeConfiguration<Anexo>
    {
        public AnexoConfiguration()
        {
            HasKey(a => a.AnexoId);

            HasRequired(a => a.Pessoa)
                .WithMany(p => p.AnexoList)
                .HasForeignKey(a => a.PessoaId);

            ToTable("Anexos");
        }
    }
}
