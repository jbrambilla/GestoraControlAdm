using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ProfissaoConfiguration : EntityTypeConfiguration<Profissao>
    {
        public ProfissaoConfiguration()
        {
            HasKey(p => p.ProfissaoId);

            ToTable("Profissao");
        }
    }
}
