using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Empresas
{
    public class EmpresaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification : ISpecification<Empresa>
    {
        public bool IsSatisfiedBy(Empresa empresa)
        {
            return !empresa.CnaeList.Where(c => c.CnaeId == empresa.CnaeId).Any();
        }
    }
}
