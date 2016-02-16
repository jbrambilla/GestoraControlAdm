using EGestora.GestoraControlAdm.Domain.Validations.Documentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Documentos
{
    [TestClass]
    public class CpfValidationTest
    {
        [TestMethod]
        public void Cpf_Valido_True()
        {
            var cpf = "32584874130";
            Assert.IsTrue(CpfValidation.Validar(cpf));
        }

        [TestMethod]
        public void Cpf_Valido_False()
        {
            var cpf = "12544874130";
            Assert.IsFalse(CpfValidation.Validar(cpf));
        }
    }
}
