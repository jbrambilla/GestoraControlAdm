using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.CodigoSegurancas
{
    [TestClass]
    public class CodigoSegurancaDataAtualDeveSerMaiorQueDataDeHojeSpecificationTest
    {

        [TestMethod]
        public void CodigoSeguranca_DataAtualMaiorQueDataDeHoje_True()
        {
            var CodigoSeguranca = new CodigoSeguranca() { DataAtual = new DateTime(2025, 03, 10, 00, 00, 00) };

            var specification = new CodigoSegurancaDataAtualDeveSerMaiorQueDataDeHojeSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(CodigoSeguranca));
        }

        [TestMethod]
        public void CodigoSeguranca_DataAtualMaiorQueDataDeHoje_False()
        {
            var CodigoSeguranca = new CodigoSeguranca() { DataAtual = new DateTime(2016, 03, 10, 00, 00, 00) };

            var specification = new CodigoSegurancaDataAtualDeveSerMaiorQueDataDeHojeSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(CodigoSeguranca));
        }
    }
}
