using System.Linq;
using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;

namespace EGestora.GestoraControlAdm.Domain.Specifications.AuditControllers
{
    public class AuditControllerDevePossuirControllerUnicoSpecification : ISpecification<AuditController>
    {
        private readonly IAuditControllerRepository _auditControllerRepository;

        public AuditControllerDevePossuirControllerUnicoSpecification(IAuditControllerRepository auditControllerRepository)
        {
            _auditControllerRepository = auditControllerRepository;
        }

        public bool IsSatisfiedBy(AuditController auditController)
        {
            return !_auditControllerRepository.GetAll().Where(a => a.ControllerName == auditController.ControllerName).Any();
        }
    }
}
