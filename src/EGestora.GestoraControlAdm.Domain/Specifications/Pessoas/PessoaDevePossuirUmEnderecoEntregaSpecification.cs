using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaDevePossuirUmEnderecoEntregaSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return pessoa.EnderecoList != null && pessoa.EnderecoList.Count(e => e.Entrega) <= 1;
        }
    }
}
