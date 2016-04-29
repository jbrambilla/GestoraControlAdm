using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IAuditControllerAppService : IDisposable
    {
        AuditControllerViewModel Add(AuditControllerViewModel auditControllerViewModel);
        AuditControllerViewModel GetById(Guid id);
        IEnumerable<AuditControllerViewModel> GetAll();
        AuditControllerViewModel Update(AuditControllerViewModel auditControllerViewModel);
        void Remove(Guid id);

        AuditActionViewModel AddAction(AuditActionViewModel auditActionViewModel);
        AuditActionViewModel UpdateAction(AuditActionViewModel auditActionViewModel);
        AuditActionViewModel GetActionById(Guid id);
        void RemoveAction(Guid id);

        IEnumerable<AuditViewModel> GetAllAudit();
        AuditViewModel GetAuditById(Guid id);
    }
}
