using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ
{
    public class PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaFisica != null)
            {
                return true;
            }

            return pessoa.PessoaJuridica != null && !String.IsNullOrEmpty(pessoa.PessoaJuridica.RazaoSocial);
        }
    }
}
