using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas.PJ
{
    [TestClass]
    public class PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_NomeFantasiaPreenchido_TrueQuandoPessoaFisicaNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { NomeFantasia = "RODOSBERTO BARBEIRO SANCHES MA." }
            };

            var validation = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomeFantasiaPreenchido_TrueQuandoPessoaFisicaaNotNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica()
            };

            var validation = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomeFantasiaPreenchido_FalseQuandoPessoaJuridicaNull()
        {
            Pessoa = new Pessoa()
            {
            };

            var validation = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomeFantasiaPreenchido_FalseQuandoPessoaJuridicaNotNullENomeFantasiaVazio()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { NomeFantasia = "" }
            };

            var validation = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_NomeFantasiaPreenchido_FalseQuandoPessoaJuridicaNotNullENomeFantasialNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica()
            };

            var validation = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }
    }
}
