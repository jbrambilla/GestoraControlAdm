using EGestora.GestoraControlAdm.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Entities
{
    [TestClass]
    public class LoteFaturamentoTest
    {
        [TestMethod]
        public void LoteFaturamento_ValorTotalComNotaDeveRetornarValorCorreto()
        {
            var valorEsperadoComNota = 111.00M;
            var valorEsperadoSemNota = 35.50M;
            var valorTotalEsperado = valorEsperadoComNota + valorEsperadoSemNota;

            var servico1 = new Servico();
            var servico2 = new Servico();

            var clienteComNota1 = new Cliente();
            var clienteServico1 = new ClienteServico() { PessoaId = clienteComNota1.PessoaId, Valor = 30.40M, ServicoId = servico1.ServicoId };
            var clienteServico2 = new ClienteServico() { PessoaId = clienteComNota1.PessoaId, Valor = 50.50M, ServicoId = servico2.ServicoId };

            clienteComNota1.ComNota = true;
            clienteComNota1.ClienteServicoList.Add(clienteServico1);
            clienteComNota1.ClienteServicoList.Add(clienteServico2);

            var clienteComNota2 = new Cliente();
            var clienteServico3 = new ClienteServico() { PessoaId = clienteComNota2.PessoaId, Valor = 20.10M, ServicoId = servico1.ServicoId };
            var clienteServico4 = new ClienteServico() { PessoaId = clienteComNota2.PessoaId, Valor = 10.00M, ServicoId = servico2.ServicoId };

            clienteComNota2.ComNota = true;
            clienteComNota2.ClienteServicoList.Add(clienteServico3);
            clienteComNota2.ClienteServicoList.Add(clienteServico4);


            var clienteSemNota1 = new Cliente();
            var clienteServico5 = new ClienteServico() { PessoaId = clienteSemNota1.PessoaId, Valor = 10M, ServicoId = servico1.ServicoId };
            var clienteServico6 = new ClienteServico() { PessoaId = clienteSemNota1.PessoaId, Valor = 5M, ServicoId = servico2.ServicoId };

            clienteSemNota1.ComNota = false;
            clienteSemNota1.ClienteServicoList.Add(clienteServico5);
            clienteSemNota1.ClienteServicoList.Add(clienteServico6);

            var clienteSemNota2 = new Cliente();
            var clienteServico7 = new ClienteServico() { PessoaId = clienteSemNota2.PessoaId, Valor = 15M, ServicoId = servico1.ServicoId };
            var clienteServico8 = new ClienteServico() { PessoaId = clienteSemNota2.PessoaId, Valor = 5.50M, ServicoId = servico2.ServicoId };

            clienteSemNota2.ComNota = false;
            clienteSemNota2.ClienteServicoList.Add(clienteServico7);
            clienteSemNota2.ClienteServicoList.Add(clienteServico8);

            var LoteFaturamento = new LoteFaturamento();

            LoteFaturamento.ClienteList.Add(clienteComNota1);
            LoteFaturamento.ClienteList.Add(clienteComNota2);
            LoteFaturamento.ClienteList.Add(clienteSemNota1);
            LoteFaturamento.ClienteList.Add(clienteSemNota2);

            Assert.AreEqual(valorEsperadoComNota, LoteFaturamento.ValorTotalComNota);
            Assert.AreEqual(valorEsperadoSemNota, LoteFaturamento.ValorTotalSemNota);
            Assert.AreEqual(valorTotalEsperado, LoteFaturamento.ValorTotalGeral);
        }
    }
}
