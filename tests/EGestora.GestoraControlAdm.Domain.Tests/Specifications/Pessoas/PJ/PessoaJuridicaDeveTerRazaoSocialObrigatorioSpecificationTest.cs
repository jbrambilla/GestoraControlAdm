using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas.PJ
{
    [TestClass]
    public class PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_RazaoSocialPreenchido_TrueQuandoPessoaFisicaNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { RazaoSocial = "RODOSBERTO BARBEIRO SANCHES MA."}
            };

            var validation = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_RazaoSocialPreenchido_TrueQuandoPessoaFisicaaNotNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica()
            };

            var validation = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_RazaoSocialPreenchido_FalseQuandoPessoaJuridicaNull()
        {
            Pessoa = new Pessoa()
            {
            };

            var validation = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_RazaoSocialPreenchido_FalseQuandoPessoaJuridicaNotNullERazaoSocialVazio()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { RazaoSocial = "" }
            };

            var validation = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_RazaoSocialPreenchido_FalseQuandoPessoaJuridicaNotNullERazaoSocialNull()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica()
            };

            var validation = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }
    }
}
