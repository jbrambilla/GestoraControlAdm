

using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaJuridicaDeveTerCnpjValidoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_Cnpj_Valido_True()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" }
            };

            var validation = new PessoaJuridicaDeveTerCnpjValidoSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_Cnpj_Valido_PessoaFisicaNotNull_True()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica()
            };

            var validation = new PessoaJuridicaDeveTerCnpjValidoSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_Cnpj_Valido_False()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000111" }
            };

            var validation = new PessoaJuridicaDeveTerCnpjValidoSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }
    }
}
