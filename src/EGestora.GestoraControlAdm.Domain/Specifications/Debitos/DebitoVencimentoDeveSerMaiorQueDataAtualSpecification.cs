using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Debitos
{
    public class DebitoVencimentoDeveSerMaiorQueDataAtualSpecification : ISpecification<Debito>
    {
        public bool IsSatisfiedBy(Debito debito)
        {
            return debito.Vencimento.CompareTo(DateTime.Now) > 0;
        }
    }
}
