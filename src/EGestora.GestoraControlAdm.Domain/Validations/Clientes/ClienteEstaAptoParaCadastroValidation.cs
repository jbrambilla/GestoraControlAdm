using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using System;

namespace EGestora.GestoraControlAdm.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cnpjUnico = new ClienteDevePossuirCnpjUnicoSpecification(clienteRepository);

            base.Add("cnpjUnico", new Rule<Cliente>(cnpjUnico, "Este CNPJ já está cadastrado."));
        }
    }
}
