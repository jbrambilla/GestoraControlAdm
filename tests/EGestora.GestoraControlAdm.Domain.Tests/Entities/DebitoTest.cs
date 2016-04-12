using EGestora.GestoraControlAdm.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Entities
{   
    [TestClass]
    public class DebitoTest
    {
        [TestMethod]
        public void Debito_ParcelaComDizimaPeriodica()
        {
            var Debito = new Debito()
            {
                Parcelas = 6,
                ValorLiquido = 152
            };

            var parcelaList = Debito.ValorParcelaList;

            Assert.AreEqual(25.35M, parcelaList[0]);
            Assert.AreEqual(25.33M, parcelaList[1]);
            Assert.AreEqual(25.33M, parcelaList[2]);
            Assert.AreEqual(25.33M, parcelaList[3]);
            Assert.AreEqual(25.33M, parcelaList[4]);
            Assert.AreEqual(25.33M, parcelaList[5]);
        }

        [TestMethod]
        public void Debito_ParcelaSemDizimaPeriodica()
        {
            var Debito = new Debito()
            {
                Parcelas = 6,
                ValorLiquido = 150
            };

            var parcelaList = Debito.ValorParcelaList;

            Assert.AreEqual(25, parcelaList[0]);
            Assert.AreEqual(25, parcelaList[1]);
            Assert.AreEqual(25, parcelaList[2]);
            Assert.AreEqual(25, parcelaList[3]);
            Assert.AreEqual(25, parcelaList[4]);
            Assert.AreEqual(25, parcelaList[5]);
        }

        [TestMethod]
        public void Debito_Vencido_True()
        {
            var Debito = new Debito()
            {
                Vencimento = new DateTime(2016, 03, 01)
            };

            Assert.IsTrue(Debito.IsVencido());
        }

        [TestMethod]
        public void Debito_Vencido_False()
        {
            var Debito = new Debito()
            {
                Vencimento = new DateTime(2026, 03, 01)
            };

            Assert.IsFalse(Debito.IsVencido());
        }
    }
}
