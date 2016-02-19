
using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaDeveSerJuridicaOuFisicaSpecification : ISpecification<Pessoa>
    {

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaFisica != null && pessoa.PessoaJuridica != null) {
                return false;
            }

            return pessoa.PessoaFisica != null || pessoa.PessoaJuridica != null;
        }
    }
}
