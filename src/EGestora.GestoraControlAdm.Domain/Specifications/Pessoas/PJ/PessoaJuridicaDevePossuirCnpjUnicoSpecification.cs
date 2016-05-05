using System;
using System.Linq;
using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ
{
    public class PessoaJuridicaDevePossuirCnpjUnicoSpecification : ISpecification<Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaJuridicaDevePossuirCnpjUnicoSpecification(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaFisica != null) {
                return true;
            }

            return pessoa.PessoaJuridica != null && _pessoaRepository.GetByCnpj(pessoa.PessoaJuridica.Cnpj) == null;
        }
    }
}
