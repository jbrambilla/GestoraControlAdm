using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Enderecos
{
    public class PessoaDevePossuirUmEnderecoPrincipalSpecification : ISpecification<Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public PessoaDevePossuirUmEnderecoPrincipalSpecification(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public bool IsSatisfiedBy(Endereco endereco)
        {
            if (!endereco.Principal)
            {
                return true;
            }

            return endereco.Principal && !_enderecoRepository.GetAllByPessoaId(endereco.PessoaId).Any(e => e.Principal);
        }
    }
}
