using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Debitos
{
    public class DebitoDevePossuirBoletoSpecification : ISpecification<Debito>
    {
        public bool IsSatisfiedBy(Debito debito)
        {
            return debito.BoletoList != null && debito.BoletoList.Any();
        }
    }
}
