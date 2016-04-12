using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.CodigoSegurancas
{
    [TestClass]
    public class CodigoSegurancaNaoDeveGerarCodigoParaClientesDevedoresSpecificationTest
    {
        [TestMethod]
        public void CodigoSeguranca_GerarParaClientesNaoDevedores_True()
        {
            var debito1 = new Debito() { PagoEm = DateTime.Now, Vencimento = new DateTime(2016, 03, 04) };
            var debito2 = new Debito() { PagoEm = DateTime.Now, Vencimento = new DateTime(2016, 03, 04) };
            var debitoList = new List<Debito>();
            debitoList.Add(debito1);
            debitoList.Add(debito2);

            var cliente = new Cliente()
            {
                DebitoList = debitoList
            };

            var codigoSeguranca = new CodigoSeguranca()
            { 
                Cliente = cliente 
            };

            var specification = new CodigoSegurancaNaoDeveGerarCodigoParaClientesDevedoresSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(codigoSeguranca));            
        }

        [TestMethod]
        public void CodigoSeguranca_NaoGerarParaClientesDevedores_False()
        {
            var debito1 = new Debito() { PagoEm = DateTime.Now, Vencimento = new DateTime(2016, 03, 04) };
            var debito2 = new Debito() { PagoEm = null, Vencimento = new DateTime(2016, 03, 04) };
            var debitoList = new List<Debito>();
            debitoList.Add(debito1);
            debitoList.Add(debito2);

            var cliente = new Cliente()
            {
                DebitoList = debitoList
            };

            var codigoSeguranca = new CodigoSeguranca()
            {
                Cliente = cliente
            };

            var specification = new CodigoSegurancaNaoDeveGerarCodigoParaClientesDevedoresSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(codigoSeguranca));      
        }
    }
}
