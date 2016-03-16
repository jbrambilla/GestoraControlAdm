using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.NotaServicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.NotaServicos
{
    [TestClass]
    public class NotaServicoDeveTerCalculoDeValoresCorretoSpecificationTest
    {
        [TestMethod]
        public void NotaServico_CalculoCorreto_True_IssNaoRetido()
        {
            /*
             * valorTotal = 250
             * aliquota = 5
             * iss = 250 * 0.005 = 12.5
             * valor liquido = 250 - 12.5 = 237.5
             */
            var clienteServico1 = new ClienteServico() { Valor = 100 };
            var clienteServico2 = new ClienteServico() { Valor = 150 };
            var cliente = new Cliente();
            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            var empresa = new Empresa() { Aliquota = 5 };

            var NotaServico = new NotaServico() 
            { 
                Empresa = empresa,
                Cliente = cliente,
                ValorLiquido = 237.5M,
                IssRetido = false
            };

            var specification = new NotaServicoDeveTerCalculoDeValoresCorretoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(NotaServico));
        }

        [TestMethod]
        public void NotaServico_CalculoCorreto_False_IssNaoRetido()
        {
            /*
             * valorTotal = 250
             * aliquota = 5
             * iss = 250 * 0.005 = 12.5
             * valor liquido = 250 - 12.5 = 237.5
             */
            var clienteServico1 = new ClienteServico() { Valor = 100 };
            var clienteServico2 = new ClienteServico() { Valor = 150 };
            var cliente = new Cliente();
            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            var empresa = new Empresa() { Aliquota = 5 };

            var NotaServico = new NotaServico() { Empresa = empresa, Cliente = cliente, ValorLiquido = 250.00M, IssRetido = false };

            var specification = new NotaServicoDeveTerCalculoDeValoresCorretoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(NotaServico));
        }

        [TestMethod]
        public void NotaServico_CalculoCorreto_True_IssRetido()
        {
            /*
             * valorTotal = 250
             * aliquota = 5
             * iss = 250 * 0.005 = 12.5
             * valor liquido = 250
             */
            var clienteServico1 = new ClienteServico() { Valor = 100 };
            var clienteServico2 = new ClienteServico() { Valor = 150 };
            var cliente = new Cliente();
            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            var empresa = new Empresa() { Aliquota = 5 };

            var NotaServico = new NotaServico()
            {
                Empresa = empresa,
                Cliente = cliente,
                ValorLiquido = 250M,
                IssRetido = true
            };

            var specification = new NotaServicoDeveTerCalculoDeValoresCorretoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(NotaServico));
        }

        [TestMethod]
        public void NotaServico_CalculoCorreto_False_IssRetido()
        {
            /*
             * valorTotal = 250
             * aliquota = 5
             * iss = 250 * 0.005 = 12.5
             * valor liquido = 250
             */
            var clienteServico1 = new ClienteServico() { Valor = 100 };
            var clienteServico2 = new ClienteServico() { Valor = 150 };
            var cliente = new Cliente();
            cliente.ClienteServicoList.Add(clienteServico1);
            cliente.ClienteServicoList.Add(clienteServico2);

            var empresa = new Empresa() { Aliquota = 5 };

            var NotaServico = new NotaServico()
            {
                Empresa = empresa,
                Cliente = cliente,
                ValorLiquido = 237.5M,
                IssRetido = true
            };

            var specification = new NotaServicoDeveTerCalculoDeValoresCorretoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(NotaServico));
        }
    }
}
