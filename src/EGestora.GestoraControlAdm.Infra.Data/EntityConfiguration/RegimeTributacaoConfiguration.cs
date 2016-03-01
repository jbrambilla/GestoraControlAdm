using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class RegimeTributacaoConfiguration : EntityTypeConfiguration<RegimeTributacao>
    {
        public RegimeTributacaoConfiguration()
        {
            HasKey(r => r.RegimeTributacaoId);

            Ignore(m => m.Display);
        }
    }
}
