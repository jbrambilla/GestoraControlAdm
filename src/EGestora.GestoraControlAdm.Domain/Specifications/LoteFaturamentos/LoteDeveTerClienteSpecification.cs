using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.LoteFaturamentos
{
    public class LoteDeveTerClienteSpecification : ISpecification<LoteFaturamento>
    {
        public bool IsSatisfiedBy(LoteFaturamento loteFaturamento)
        {
            return loteFaturamento.ClienteList != null && loteFaturamento.ClienteList.Any();
        }
    }
}
