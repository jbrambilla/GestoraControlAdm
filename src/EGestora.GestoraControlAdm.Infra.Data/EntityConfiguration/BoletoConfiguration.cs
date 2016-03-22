using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class BoletoConfiguration : EntityTypeConfiguration<Boleto>
    {
        public BoletoConfiguration()
        {
            HasKey(b => b.BoletoId);

            HasRequired(b => b.Debito)
                .WithMany(d => d.BoletoList)
                .HasForeignKey(b => b.DebitoId);

            ToTable("Boletos");
        }
    }
}
