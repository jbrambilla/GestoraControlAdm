using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDeveSerJuridicaOuFisicaSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_JuridicaOuFisica_Juridica_True()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() };
            var validation = new PessoaDeveSerJuridicaOuFisicaSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_JuridicaOuFisica_Fisica_True()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() };
            var validation = new PessoaDeveSerJuridicaOuFisicaSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_JuridicaOuFisica_FisicaIsNull_JuridicaIsNull_False()
        {
            Pessoa = new Pessoa() { };
            var validation = new PessoaDeveSerJuridicaOuFisicaSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_JuridicaOuFisica_FisicaIsNotNull_JuridicaIsNotNull_False()
        {
            Pessoa = new Pessoa() { };
            var validation = new PessoaDeveSerJuridicaOuFisicaSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

    }
}
