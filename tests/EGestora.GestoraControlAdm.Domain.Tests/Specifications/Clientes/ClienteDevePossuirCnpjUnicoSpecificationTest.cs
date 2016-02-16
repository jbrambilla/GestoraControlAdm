using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Clientes
{
    [TestClass]
    public class ClienteDevePossuirCnpjUnicoSpecificationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_CnpjUnico_True()
        {
            Cliente = new Cliente() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.GetByCnpj(Cliente.PessoaJuridica.Cnpj)).Return(null);

            var specification = new ClienteDevePossuirCnpjUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void Cliente_CnpjUnico_False()
        {
            Cliente = new Cliente() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.GetByCnpj(Cliente.PessoaJuridica.Cnpj)).Return(Cliente);

            var specification = new ClienteDevePossuirCnpjUnicoSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(Cliente));
        }
    }
}
