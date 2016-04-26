using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class AuditAction
    {
        public AuditAction()
        {
            AuditActionId = Guid.NewGuid();
        }

        public Guid AuditActionId { get; set; }
        public Guid AuditControllerId { get; set; }
        public string ActionName { get; set; }

        public virtual AuditController AuditController { get; set; }
    }
}
