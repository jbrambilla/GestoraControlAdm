using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Documentos;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF
{
    public class PessoaFisicaDeveTerCpfValidoSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaJuridica != null) {
                return true;
            }
            return pessoa.PessoaFisica != null && !String.IsNullOrEmpty(pessoa.PessoaFisica.Cpf) && CpfValidation.Validar(pessoa.PessoaFisica.Cpf);
        }
    }
}
