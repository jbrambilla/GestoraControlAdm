using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.LoteFaturamentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.LoteFaturamentos
{
    [TestClass]
    public class LoteFaturamentoEstaConsistenteValidationTest
    {
        [TestMethod]
        public void Lote_Consistente_True()
        {
            var LoteFaturamento = new LoteFaturamento();
            LoteFaturamento.ClienteList.Add(new Cliente());

            var validation = new LoteFaturamentoEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(LoteFaturamento).IsValid);
        }

        [TestMethod]
        public void Lote_Consistente_False()
        {
            var LoteFaturamento = new LoteFaturamento();

            var validation = new LoteFaturamentoEstaConsistenteValidation();
            var validationResult = validation.Validate(LoteFaturamento);

            Assert.IsFalse(validationResult.IsValid);
            Assert.IsTrue(validationResult.Erros.Any(e => e.Message == "Para salvar o Lote, é necessário selecionar pelo menos um cliente."));
        }
    }
}
