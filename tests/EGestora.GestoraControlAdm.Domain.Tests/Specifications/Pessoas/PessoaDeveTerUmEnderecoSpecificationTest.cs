using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDeveTerUmEnderecoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_PossuiEndereco_True()
        {
            Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(new Endereco());

            var specification = new PessoaDeveTerUmEnderecoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_PossuiEndereco_False()
        {
            Pessoa = new Pessoa();

            var specification = new PessoaDeveTerUmEnderecoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
