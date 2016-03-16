using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Debitos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Debitos
{
    [TestClass]
    public class DebitoVencimentoDeveSerMaiorQueDataAtualSpecificationTest
    {
        [TestMethod]
        public void Debito_VencimentoMaiorQueDataAtual_True()
        {
            var Debito = new Debito() { Vencimento = new DateTime(2025, 03, 10, 00, 00, 00) };

            var specification = new DebitoVencimentoDeveSerMaiorQueDataAtualSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Debito));
        }

        [TestMethod]
        public void Debito_VencimentoMaiorQueDataAtual_False()
        {
            var Debito = new Debito() { Vencimento = new DateTime(2016, 03, 10, 00, 00, 00) };

            var specification = new DebitoVencimentoDeveSerMaiorQueDataAtualSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Debito));
        }
    }
}
