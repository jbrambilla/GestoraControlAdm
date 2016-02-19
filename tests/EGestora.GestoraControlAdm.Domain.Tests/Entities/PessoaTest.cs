using EGestora.GestoraControlAdm.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Entities
{
    [TestClass]
    public class PessoaTest
    {
        [TestMethod]
        public void Pessoa_IsPessoaJuridica_True()
        {
            var Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() };

            Assert.IsTrue(Pessoa.IsPessoaJuridica);
            Assert.IsFalse(Pessoa.IsPessoaFisica);
        }

        [TestMethod]
        public void Pessoa_IsPessoaJuridica_PessoaJuridicaNotNull_PessoaFisicaNotNull_False()
        {
            var Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica(), PessoaFisica = new PessoaFisica() };

            Assert.IsFalse(Pessoa.IsPessoaJuridica);
            Assert.IsFalse(Pessoa.IsPessoaFisica);
        }

        [TestMethod]
        public void Pessoa_IsPessoaJuridica_PessoaJuridicaNull_PessoaFisicaNull_False()
        {
            var Pessoa = new Pessoa();

            Assert.IsFalse(Pessoa.IsPessoaJuridica);
            Assert.IsFalse(Pessoa.IsPessoaFisica);
        }

        [TestMethod]
        public void Pessoa_IsPessoaFisica_True()
        {
            var Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() };

            Assert.IsFalse(Pessoa.IsPessoaJuridica);
            Assert.IsTrue(Pessoa.IsPessoaFisica);
        }

        
    }
}
