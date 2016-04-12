using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.CodigoSegurancas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.CodigoSegurancas
{
    [TestClass]
    public class CodigoSegurancaEstaConsistenteValidationTest
    {
        [TestMethod]
        public void CodigoSeguranca_Consistente_True()
        {
            var CodigoSeguranca = new CodigoSeguranca() { 
                DataTrava = new DateTime(2025, 03, 11, 00, 00, 00)
            };

            var validation = new CodigoSegurancaEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(CodigoSeguranca).IsValid);
        }

        [TestMethod]
        public void CodigoSeguranca_Consistente_False()
        {
            var CodigoSeguranca = new CodigoSeguranca()
            {
                DataTrava = new DateTime(2016, 04, 01, 00, 00, 00)
            };

            var validation = new CodigoSegurancaEstaConsistenteValidation();
            var validationResult = validation.Validate(CodigoSeguranca);

            Assert.IsFalse(validationResult.IsValid);
            Assert.IsTrue(validationResult.Erros.Any(e => e.Message == "A Data da Trava deve ser maior que a data de hoje."));
        }
    }
}
