using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class DebitoConfiguration : EntityTypeConfiguration<Debito>
    {
        public DebitoConfiguration()
        {
            HasKey(d => d.DebitoId);

            Property(d => d.PagoEm)
                .IsOptional();

            Property(d => d.Desconto)
                .IsOptional();

            Property(d => d.Juros)
                .IsOptional();

            Property(d => d.Multa)
                .IsOptional();

            Property(d => d.ValorPago)
                .IsOptional();

            HasRequired(d => d.Cliente)
                .WithMany(c => c.DebitoList)
                .HasForeignKey(d => d.ClienteId);

            Ignore(d => d.ValidationResult);

            Ignore(d => d.ValorParcelaList);

            ToTable("Debitos");
        }
    }
}
