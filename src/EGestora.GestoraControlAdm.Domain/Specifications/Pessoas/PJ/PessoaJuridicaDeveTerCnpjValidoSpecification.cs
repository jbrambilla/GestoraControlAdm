using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Documentos;
using System;

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
            return pessoa.PessoaJuridica != null && !String.IsNullOrEmpty(pessoa.PessoaJuridica.Cnpj) && CnpjValidation.Validar(pessoa.PessoaJuridica.Cnpj);
        }
    }
}
