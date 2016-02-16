using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;


namespace EGestora.GestoraControlAdm.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmaPessoaJuridicaSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.PessoaJuridica != null;
        }
    }
}
