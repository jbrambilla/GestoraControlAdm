﻿

using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaFisicaDeveTerCpfValidoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_Cpf_Valido_True()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica() { Cpf = "52967264644" }
            };

            var validation = new PessoaFisicaDeveTerCpfValidoSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_Cpf_Valido_PessoaJuridicaNotNull_True()
        {
            Pessoa = new Pessoa()
            {
                PessoaJuridica = new PessoaJuridica()
            };

            var validation = new PessoaFisicaDeveTerCpfValidoSpecification();
            Assert.IsTrue(validation.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_Cpf_Valido_False()
        {
            Pessoa = new Pessoa()
            {
                PessoaFisica = new PessoaFisica() { Cpf = "52967264111" }
            };

            var validation = new PessoaFisicaDeveTerCpfValidoSpecification();
            Assert.IsFalse(validation.IsSatisfiedBy(Pessoa));
        }
    }
}
