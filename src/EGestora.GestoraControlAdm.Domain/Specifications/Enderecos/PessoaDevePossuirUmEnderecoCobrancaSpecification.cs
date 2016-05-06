using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Enderecos
{
    public class PessoaDevePossuirUmEnderecoCobrancaSpecification : ISpecification<Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public PessoaDevePossuirUmEnderecoCobrancaSpecification(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public bool IsSatisfiedBy(Endereco endereco)
        {
            if (!endereco.Cobranca)
            {
                return true;
            }

            return endereco.Cobranca && !_enderecoRepository.GetAllByPessoaId(endereco.PessoaId).Any(e => e.Cobranca);
        }
    }
}
