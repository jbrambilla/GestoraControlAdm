using EGestora.GestoraControlAdm.Domain.Validations.Documentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Documentos
{
    [TestClass]
    public class CnpjValidationTest
    {
        [TestMethod]
        public void Cnpj_Valido_True()
        {
            var cnpj = "34625757000192";
            Assert.IsTrue(CnpjValidation.Validar(cnpj));
        }

        [TestMethod]
        public void Cnpj_Valido_False()
        {
            var cnpj = "34625757000112";
            Assert.IsFalse(CnpjValidation.Validar(cnpj));
        }
    }
}

