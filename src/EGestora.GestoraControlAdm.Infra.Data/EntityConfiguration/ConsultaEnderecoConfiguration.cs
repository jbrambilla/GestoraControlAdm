using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ConsultaEnderecoConfiguration : EntityTypeConfiguration<ConsultaEndereco>
    {
        public ConsultaEnderecoConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .HasMaxLength(500);

            Property(e => e.Cidade)
                .HasMaxLength(500);

            ToTable("ConsultaEndereco");
        }
    }
}
