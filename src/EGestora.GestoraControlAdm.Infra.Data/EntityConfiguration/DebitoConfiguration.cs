using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class DebitoConfiguration : EntityTypeConfiguration<Debito>
    {
        public DebitoConfiguration()
        {
            HasKey(d => d.DebitoId);

            HasRequired(d => d.Cliente)
                .WithMany(c => c.DebitoList)
                .HasForeignKey(d => d.ClienteId);

            Ignore(d => d.ValidationResult);

            ToTable("Debitos");
        }
    }
}
