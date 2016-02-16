using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Clientes
{
    [TestClass]
    public class ClienteEstaAptoParaCadastroValidationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_Apto_True()
        {
            Cliente = new Cliente() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.GetByCnpj(Cliente.PessoaJuridica.Cnpj)).Return(null);

            var validation = new ClienteEstaAptoParaCadastroValidation(stubRepo);

            Assert.IsTrue(validation.Validate(Cliente).IsValid);
        }

        [TestMethod]
        public void Cliente_Apto_False()
        {
            Cliente = new Cliente() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.GetByCnpj(Cliente.PessoaJuridica.Cnpj)).Return(Cliente);

            var validation = new ClienteEstaAptoParaCadastroValidation(stubRepo);
            var result = validation.Validate(Cliente);

            Assert.IsFalse(validation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Este CNPJ já está cadastrado."));
        }
    }
}
