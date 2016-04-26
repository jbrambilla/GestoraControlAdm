using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.AuditControllers;

namespace EGestora.GestoraControlAdm.Domain.Validations.AuditControllers
{
    public class AuditControllerEstaAptoParaCadastroValidation : Validator<AuditController>
    {
        public AuditControllerEstaAptoParaCadastroValidation(IAuditControllerRepository auditControllerRepository)
        {
            var controllerUnico = new AuditControllerDevePossuirControllerUnicoSpecification(auditControllerRepository);

            base.Add("controllerUnico", new Rule<AuditController>(controllerUnico, "Este Controller já existe na lista de Auditoria."));
        }
    }
}
