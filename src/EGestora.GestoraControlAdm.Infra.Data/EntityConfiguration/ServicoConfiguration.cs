using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ServicoConfiguration : EntityTypeConfiguration<Servico>
    {
        public ServicoConfiguration()
        {
            HasKey(s => s.ServicoId);

            HasMany(c => c.ClienteServicoList)
                .WithRequired(cs => cs.Servico)
                .HasForeignKey(cs => cs.ServicoId);

            ToTable("Servicos");
        }
    }
}
