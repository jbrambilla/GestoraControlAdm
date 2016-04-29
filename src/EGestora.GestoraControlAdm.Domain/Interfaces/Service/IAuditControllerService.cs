using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IAuditControllerService : IDisposable
    {
        AuditController Add(AuditController auditController);
        AuditController GetById(Guid id);
        IEnumerable<AuditController> GetAll();
        AuditController Update(AuditController auditController);
        void Remove(Guid id);

        AuditAction AddAction(AuditAction auditAction);
        AuditAction UpdateAction(AuditAction auditAction);
        AuditAction GetActionById(Guid id);
        void RemoveAction(Guid id);

        IEnumerable<Audit> GetAllAudit();
        Audit GetAuditById(Guid id);
    }
}
