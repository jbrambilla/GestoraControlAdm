using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.LoteFaturamentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.LoteFaturamentos
{
    [TestClass]
    public class LoteDeveTerClienteSpecificationTest
    {
        public LoteFaturamento LoteFaturamento { get; set; }

        [TestMethod]
        public void Lote_PossuiCliente_True()
        {
            LoteFaturamento = new LoteFaturamento();
            LoteFaturamento.ClienteList.Add(new Cliente());

            var specification = new LoteDeveTerClienteSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(LoteFaturamento));
        }

        [TestMethod]
        public void Lote_PossuiCliente_False()
        {
            LoteFaturamento = new LoteFaturamento();

            var specification = new LoteDeveTerClienteSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(LoteFaturamento));
        }
    }
}
