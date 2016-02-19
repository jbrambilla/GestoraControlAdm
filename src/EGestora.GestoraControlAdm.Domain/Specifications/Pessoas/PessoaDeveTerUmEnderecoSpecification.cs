using System.Linq;
using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaDeveTerUmEnderecoSpecification : ISpecification<Pessoa>
    {

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return pessoa.EnderecoList != null && pessoa.EnderecoList.Any();
        }
    }
}
