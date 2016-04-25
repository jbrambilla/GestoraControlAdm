using EGestora.GestoraControlAdm.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void Cliente_DiscriminacaoServicosDeveRetornarNomeDeTodosServicos()
        {
            var expected = "Serviço 1, Serviço 2";

            var servico1 = new Servico() { Descricao = "Serviço 1" };
            var servico2 = new Servico() { Descricao = "Serviço 2" };
            var cliente = new Cliente();

            var clienteServico1 = new ClienteServico() { PessoaId = cliente.PessoaId, ServicoId = servico1.ServicoId, Servico = servico1 };
            var clienteServico2 = new ClienteServico() { PessoaId = cliente.PessoaId, ServicoId = servico2.ServicoId, Servico = servico2 };

            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            Assert.AreEqual(expected, cliente.DiscriminacaoServicos);
        }

        [TestMethod]
        public void Cliente_ObterUltimoDebitoAtivo()
        {
            var debito1 = new Debito() { CriadoEm = DateTime.Now };
            var debito2 = new Debito() { CriadoEm = DateTime.Now.AddDays(-30) };
            var Cliente = new Cliente();
            Cliente.DebitoList.Add(debito1);
            Cliente.DebitoList.Add(debito2);

            Assert.AreEqual(DateTime.Now.Date, Cliente.ObterUltimoDebitoAtivo().CriadoEm.Date);
        }
    }
}
