using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class EnquadramentoServicoConfiguration : EntityTypeConfiguration<EnquadramentoServico>
    {
        public EnquadramentoServicoConfiguration()
        {
            HasKey(e => e.EnquadramentoServicoId);

            Ignore(m => m.Display);
        }
    }
}
