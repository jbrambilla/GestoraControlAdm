using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using System;

namespace EGestora.GestoraControlAdm.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var cnpjCliente = new ClienteDeveTerCnpjValidoSpecification();
            var clientePessoaJuridica = new ClienteDeveTerUmaPessoaJuridicaSpecification();
            var clienteEndereco = new ClienteDeveTerUmEnderecoSpecification();

            base.Add("cnpjCliente", new Rule<Cliente>(cnpjCliente, "Cliente informou um CNPJ inválido."));
            base.Add("clientePessoaJuridica", new Rule<Cliente>(clientePessoaJuridica, "Cliente precisa possuir uma Pessoa Jurídica."));
            base.Add("clienteEndereco", new Rule<Cliente>(clienteEndereco, "Cliente precisa possuir um Endereço."));
        }
    }
}
