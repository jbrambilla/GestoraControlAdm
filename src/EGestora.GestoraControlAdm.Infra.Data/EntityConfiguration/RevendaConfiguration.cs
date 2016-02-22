using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class RevendaConfiguration : EntityTypeConfiguration<Revenda>
    {
        public RevendaConfiguration()
        {
            ToTable("Revendas");
        }
    }
}
