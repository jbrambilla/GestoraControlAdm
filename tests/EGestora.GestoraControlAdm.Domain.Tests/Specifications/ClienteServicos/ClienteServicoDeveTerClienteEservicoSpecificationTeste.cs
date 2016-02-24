using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.ClienteServicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.ClienteServicos
{
    [TestClass]
    public class ClienteServicoDeveTerClienteEservicoSpecificationTeste
    {
        public ClienteServico ClienteServico { get; set; }

        [TestMethod]
        public void ClienteServico_TemClienteEservico_True()
        {
            ClienteServico = new ClienteServico() { Cliente = new Cliente(), Servico = new Servico() };

            var specification = new ClienteServicoDeveTerClienteEservicoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(ClienteServico));
        }

        [TestMethod]
        public void ClienteServico_TemClienteEnaoTemServico_False()
        {
            ClienteServico = new ClienteServico() { Cliente = new Cliente() };

            var specification = new ClienteServicoDeveTerClienteEservicoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(ClienteServico));
        }

        [TestMethod]
        public void ClienteServico_NaoTemClienteEtemServico_False()
        {
            ClienteServico = new ClienteServico() { Servico = new Servico() };

            var specification = new ClienteServicoDeveTerClienteEservicoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(ClienteServico));
        }

        [TestMethod]
        public void ClienteServico_NaoTemClienteEnaoTemServico_False()
        {
            ClienteServico = new ClienteServico();

            var specification = new ClienteServicoDeveTerClienteEservicoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(ClienteServico));
        }
    }
}
