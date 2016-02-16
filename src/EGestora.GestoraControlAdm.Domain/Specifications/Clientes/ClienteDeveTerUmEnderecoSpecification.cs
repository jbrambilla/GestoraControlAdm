using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;


namespace EGestora.GestoraControlAdm.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmEnderecoSpecification : ISpecification<Cliente>
    {

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.PessoaJuridica != null && cliente.PessoaJuridica.EnderecoList != null && cliente.PessoaJuridica.EnderecoList.Any();
        }
    }
}
