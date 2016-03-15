using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDeveTerUmContatoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_PossuiContato_True()
        {
            Pessoa = new Pessoa();
            Pessoa.ContatoList.Add(new Contato());

            var specification = new PessoaDeveTerUmContatoSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_PossuiContato_False()
        {
            Pessoa = new Pessoa();

            var specification = new PessoaDeveTerUmContatoSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
