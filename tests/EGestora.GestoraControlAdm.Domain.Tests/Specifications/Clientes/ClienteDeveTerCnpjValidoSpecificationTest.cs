using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Clientes
{
    [TestClass]
    public class ClienteDeveTerCnpjValidoSpecificationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_Cnpj_Valido_True()
        {
            Cliente = new Cliente()
            {
                PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" }
            };

            var clienteValidation = new ClienteDeveTerCnpjValidoSpecification();
            Assert.IsTrue(clienteValidation.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void Cliente_Cnpj_Valido_False()
        {
            Cliente = new Cliente()
            {
                PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000111" }
            };

            var clienteValidation = new ClienteDeveTerCnpjValidoSpecification();
            Assert.IsFalse(clienteValidation.IsSatisfiedBy(Cliente));
        }
    }
}
