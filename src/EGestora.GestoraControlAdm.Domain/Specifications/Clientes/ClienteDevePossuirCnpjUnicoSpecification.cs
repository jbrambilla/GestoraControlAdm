using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirCnpjUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienterepository;

        public ClienteDevePossuirCnpjUnicoSpecification(IClienteRepository clienterepository)
        {
            _clienterepository = clienterepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.PessoaJuridica != null && _clienterepository.GetByCnpj(cliente.PessoaJuridica.Cnpj) == null;
        }
    }
}
