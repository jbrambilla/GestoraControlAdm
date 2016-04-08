using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class CodigoSegurancaConfiguration : EntityTypeConfiguration<CodigoSeguranca>
    {
        public CodigoSegurancaConfiguration()
        {
            HasKey(cs => cs.CodigoSegurancaId);

            Property(cs => cs.Codigo)
                .IsRequired()
                .HasMaxLength(12);

            HasRequired(cs => cs.Cliente)
                .WithMany(c => c.CodigoSegurancaList)
                .HasForeignKey(cs => cs.ClienteId);

            Ignore(cs => cs.ValidationResult);
        }
    }
}
