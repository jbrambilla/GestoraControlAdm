using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas
{
    public class PessoaFisicaDevePossuirCpfUnicoSpecification<TEntity> : ISpecification<Pessoa> where TEntity : class
    {
        private readonly IPessoaRepository<TEntity> _pessoaRepository;

        public PessoaFisicaDevePossuirCpfUnicoSpecification(IPessoaRepository<TEntity> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaJuridica != null) {
                return true;
            }

            return pessoa.PessoaFisica != null && _pessoaRepository.GetByCpf(pessoa.PessoaFisica.Cpf) == null;
        }
    }
}
