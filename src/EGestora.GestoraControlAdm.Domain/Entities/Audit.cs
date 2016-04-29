using DomainValidation.Validation;
using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Audit
    {
        public Audit()
        {
            AuditId = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public Guid AuditId { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
