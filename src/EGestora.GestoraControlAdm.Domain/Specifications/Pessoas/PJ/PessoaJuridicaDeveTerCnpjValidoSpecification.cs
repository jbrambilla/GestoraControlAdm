using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Documentos;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ
{
    public class PessoaJuridicaDeveTerCnpjValidoSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaFisica != null)
            {
                return true;
            }
            return pessoa.PessoaJuridica != null && CnpjValidation.Validar(pessoa.PessoaJuridica.Cnpj);
        }
    }
}
