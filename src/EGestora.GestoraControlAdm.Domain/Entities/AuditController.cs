using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class AuditController
    {
        public AuditController()
        {
            AuditControllerId = Guid.NewGuid();
            AuditActionList = new List<AuditAction>();
        }

        public Guid AuditControllerId { get; set; }
        public string ControllerName { get; set; }

        public virtual ICollection<AuditAction> AuditActionList { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
