using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class CnaeConfiguration : EntityTypeConfiguration<Cnae>
    {
        public CnaeConfiguration()
        {
            HasKey(c => c.CnaeId);

            Ignore(m => m.Display);

            ToTable("Cnaes");
        }
    }
}
