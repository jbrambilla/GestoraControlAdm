using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Debitos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Debitos
{
    [TestClass]
    public class DebitoDevePossuirBoletoSpecificationTest
    {
        [TestMethod]
        public void Debito_PossuiBoleto_True()
        {
            var Debito = new Debito();
            Debito.BoletoList.Add(new Boleto());

            var specification = new DebitoDevePossuirBoletoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Debito));
        }

        [TestMethod]
        public void Debito_PossuiBoleto_False()
        {
            var Debito = new Debito();

            var specification = new DebitoDevePossuirBoletoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Debito));
        }
    }
}
