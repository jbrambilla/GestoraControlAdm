using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class AuditActionConfiguration : EntityTypeConfiguration<AuditAction>
    {
        public AuditActionConfiguration()
        {
            HasKey(a => a.AuditActionId);

            HasRequired(a => a.AuditController)
                .WithMany(ac => ac.AuditActionList)
                .HasForeignKey(a => a.AuditControllerId);

            ToTable("AuditActions");
        }
    }
}
