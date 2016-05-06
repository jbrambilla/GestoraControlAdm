using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaDevePossuirUmEnderecoCobrancaSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return pessoa.EnderecoList != null && pessoa.EnderecoList.Count(e => e.Cobranca) <= 1;
        }
    }
}
