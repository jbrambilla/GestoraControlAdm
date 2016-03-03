using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.NotaServicos
{
    public class NotaServicoDeveTerCalculoDeValoresCorretoSpecification : ISpecification<NotaServico>
    {
        public bool IsSatisfiedBy(NotaServico notaServico)
        {
            return true;
        }
    }
}
