using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class RegimeApuracaoConfiguration : EntityTypeConfiguration<RegimeApuracao>
    {
        public RegimeApuracaoConfiguration()
        {
            HasKey(r => r.RegimeApuracaoId);

            Ignore(m => m.Display);
        }
    }
}
