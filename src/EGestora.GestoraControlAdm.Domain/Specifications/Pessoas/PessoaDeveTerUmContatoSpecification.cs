using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaDeveTerUmContatoSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return pessoa.ContatoList != null && pessoa.ContatoList.Any();
        }
    }
}
