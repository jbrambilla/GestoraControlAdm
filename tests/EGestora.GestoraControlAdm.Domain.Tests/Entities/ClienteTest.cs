using EGestora.GestoraControlAdm.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Entities
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void Cliente_ValorTotalServicosDeveRetornarValorCorreto_True()
        {
            var valorEsperado = 80.90M;

            var servico1 = new Servico();
            var servico2 = new Servico();
            var cliente = new Cliente();

            var clienteServico1 = new ClienteServico() { PessoaId = cliente.PessoaId, Valor = 30.40M, ServicoId = servico1.ServicoId };
            var clienteServico2 = new ClienteServico() { PessoaId = cliente.PessoaId, Valor = 50.50M, ServicoId = servico2.ServicoId };

            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            Assert.AreEqual(valorEsperado, cliente.ValorTotalServicos);
        }
    }
}
