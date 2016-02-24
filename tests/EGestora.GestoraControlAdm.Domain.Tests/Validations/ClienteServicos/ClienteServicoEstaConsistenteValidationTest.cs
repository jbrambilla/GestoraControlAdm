using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.ClienteServicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.ClienteServicos
{
    [TestClass]
    public class ClienteServicoEstaConsistenteValidationTest
    {
        [TestMethod]
        public void ClienteServico_EstaConsistente_True()
        {
            var ClienteServico = new ClienteServico() { Cliente = new Cliente(), Servico = new Servico() };

            var validation = new ClienteServicoEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(ClienteServico).IsValid);
        }

        [TestMethod]
        public void ClienteServico_EstaConsistente_False()
        {
            var ClienteServico = new ClienteServico();

            var validation = new ClienteServicoEstaConsistenteValidation();
            var result = validation.Validate(ClienteServico);

            Assert.IsFalse(validation.Validate(ClienteServico).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "É necessário selecionar um cliente e um serviço."));

        }
    }
}
