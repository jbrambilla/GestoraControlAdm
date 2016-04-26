using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class AuditConfiguration : EntityTypeConfiguration<Audit>
    {
        public AuditConfiguration()
        {
            HasKey(a => a.AuditId);

            ToTable("Audit");
        }
    }
}
