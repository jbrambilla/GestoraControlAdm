using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas.PF
{
    [TestClass]
    public class PessoaFisicaDeveTerNomeObrigatorioSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_NomePreenchido_TrueQuandoPessoaJuridicaNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica() { Nome = "José Gralha" }
            };

            var validation = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomePreenchido_TrueQuandoPessoaJuridicaNotNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica()
            };

            var validation = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomePreenchido_FalseQuandoPessoaFisicaNull()
        {
            Pessoa = new Pessoa();

            var validation = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomePreenchido_FalseQuandoPessoaFisicaNotNullENomeVazio()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica() { Nome = ""}
            };

            var validation = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomePreenchido_FalseQuandoPessoaFisicaNotNullENomeNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica()
            };

            var validation = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }
    }
}
