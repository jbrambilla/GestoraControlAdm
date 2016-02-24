using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ClienteServicoConfiguration : EntityTypeConfiguration<ClienteServico>
    {
        public ClienteServicoConfiguration()
        {
            HasKey(cs => cs.ClienteServicoId);

            Ignore(cs => cs.ValidationResult);

            ToTable("ClienteServico");
        }
    }
}
