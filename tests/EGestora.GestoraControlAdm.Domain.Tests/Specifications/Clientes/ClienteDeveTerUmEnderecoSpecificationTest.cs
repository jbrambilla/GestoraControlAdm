using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Clientes
{
    [TestClass]
    public class ClienteDeveTerUmEnderecoSpecificationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_PossuiEndereco_True()
        {
            var pessoaJuridica = new PessoaJuridica();
            pessoaJuridica.EnderecoList.Add(new Endereco());
            Cliente = new Cliente() { PessoaJuridica = pessoaJuridica };

            var specification = new ClienteDeveTerUmEnderecoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void Cliente_PossuiEndereco_False()
        {
            var pessoaJuridica = new PessoaJuridica();
            Cliente = new Cliente() { PessoaJuridica = pessoaJuridica };

            var specification = new ClienteDeveTerUmEnderecoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Cliente));
        }
    }
}
