using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Enderecos
{
    public class PessoaDevePossuirUmEnderecoEntregaSpecification : ISpecification<Endereco>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public PessoaDevePossuirUmEnderecoEntregaSpecification(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public bool IsSatisfiedBy(Endereco endereco)
        {
            if (!endereco.Entrega)
            {
                return true;
            }

            return endereco.Entrega && !_enderecoRepository.GetAllByPessoaId(endereco.PessoaId).Any(e => e.Entrega);
        }
    }
}
