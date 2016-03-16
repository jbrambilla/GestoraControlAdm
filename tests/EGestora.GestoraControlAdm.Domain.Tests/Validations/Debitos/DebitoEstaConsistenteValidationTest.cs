using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Debitos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Debitos
{
    [TestClass]
    public class DebitoEstaConsistenteValidationTest
    {
        [TestMethod]
        public void Debito_Consistente_True()
        {
            var Debito = new Debito() { Vencimento = new DateTime(2025, 03, 10, 00, 00, 00) };

            var validation = new DebitoEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(Debito).IsValid);
        }

        [TestMethod]
        public void Debito_Consistente_False()
        {
            var Debito = new Debito() { Vencimento = new DateTime(2016, 03, 10, 00, 00, 00) };

            var validation = new DebitoEstaConsistenteValidation();
            var validationResult = validation.Validate(Debito);

            Assert.IsFalse(validationResult.IsValid);
            Assert.IsTrue(validationResult.Erros.Any(e => e.Message == "A data de vencimento deve ser maior que a data atual."));
        }
    }
}
