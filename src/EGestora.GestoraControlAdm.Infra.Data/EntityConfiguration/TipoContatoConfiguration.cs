using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class TipoContatoConfiguration : EntityTypeConfiguration<TipoContato>
    {
        public TipoContatoConfiguration()
        {
            HasKey(tc => tc.TipoContatoId);

            ToTable("TipoContato");
        }
    }
}
