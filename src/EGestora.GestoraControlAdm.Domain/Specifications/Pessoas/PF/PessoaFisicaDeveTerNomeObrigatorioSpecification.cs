using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF
{
    public class PessoaFisicaDeveTerNomeObrigatorioSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaJuridica != null)
            {
                return true;
            }

            return pessoa.PessoaFisica != null && !string.IsNullOrEmpty(pessoa.PessoaFisica.Nome);
        }
    }
}
