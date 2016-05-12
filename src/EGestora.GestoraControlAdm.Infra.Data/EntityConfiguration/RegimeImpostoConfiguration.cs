using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class RegimeImpostoConfiguration : EntityTypeConfiguration<RegimeImposto>
    {
        public RegimeImpostoConfiguration()
        {
            HasKey(r => r.RegimeImpostoId);

            ToTable("RegimeImposto");
        }
    }
}
