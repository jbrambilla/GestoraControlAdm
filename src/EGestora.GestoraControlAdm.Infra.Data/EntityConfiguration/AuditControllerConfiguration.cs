using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class AuditControllerConfiguration : EntityTypeConfiguration<AuditController>
    {
        public AuditControllerConfiguration()
        {
            HasKey(a => a.AuditControllerId);

            Ignore(a => a.ValidationResult);

            ToTable("AuditControllers");
        }
    }
}
