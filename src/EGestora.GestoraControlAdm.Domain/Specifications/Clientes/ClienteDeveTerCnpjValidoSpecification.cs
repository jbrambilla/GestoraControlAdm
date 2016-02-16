using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Documentos;
using System;


namespace EGestora.GestoraControlAdm.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCnpjValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.PessoaJuridica != null && CnpjValidation.Validar(cliente.PessoaJuridica.Cnpj);
        }
    }
}
