using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Clientes
{
    [TestClass]
    public class ClienteDeveTerUmaPessoaJuridicaSpecificationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_PossuiPessoaJuridica_True()
        {
            Cliente = new Cliente() { PessoaJuridica = new PessoaJuridica() };

            var clienteValidation = new ClienteDeveTerUmaPessoaJuridicaSpecification();
            Assert.IsTrue(clienteValidation.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void Cliente_PossuiPessoaJuridica_False()
        {
            Cliente = new Cliente();

            var clienteValidation = new ClienteDeveTerUmaPessoaJuridicaSpecification();
            Assert.IsFalse(clienteValidation.IsSatisfiedBy(Cliente));
        }
    }
}
