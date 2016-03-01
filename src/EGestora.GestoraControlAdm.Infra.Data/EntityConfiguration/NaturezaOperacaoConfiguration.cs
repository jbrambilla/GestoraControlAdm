using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class NaturezaOperacaoConfiguration : EntityTypeConfiguration<NaturezaOperacao>
    {
        public NaturezaOperacaoConfiguration()
        {
            HasKey(n => n.NaturezaOperacaoId);

            Ignore(m => m.Display);
        }
    }
}
