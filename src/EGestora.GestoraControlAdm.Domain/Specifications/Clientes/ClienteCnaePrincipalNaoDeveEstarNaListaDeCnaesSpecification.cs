using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Clientes
{
    public class ClienteCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return !cliente.CnaeList.Where(c => c.CnaeId == cliente.CnaeId).Any();
        }
    }
}