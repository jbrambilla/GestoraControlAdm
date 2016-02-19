using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Documentos;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF
{
    public class PessoaFisicaDeveTerCpfValidoSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaJuridica != null) {
                return true;
            }
            return pessoa.PessoaFisica != null && CpfValidation.Validar(pessoa.PessoaFisica.Cpf);
        }
    }
}
