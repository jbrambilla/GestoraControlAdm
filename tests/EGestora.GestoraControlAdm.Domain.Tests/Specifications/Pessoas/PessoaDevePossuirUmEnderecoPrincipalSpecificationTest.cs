using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoPrincipalSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoPrincipal_TrueQuandoPossuiApenasUmEnderecoPrincipal()
        {
            var endereco1 = new Endereco()
            {
                Principal = true
            };

            var endereco2 = new Endereco()
            {
                Principal = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoPrincipal_TrueQuandoPossuiNenhumEnderecoPrincipal()
        {
            var endereco1 = new Endereco()
            {
                Principal = false
            };

            var endereco2 = new Endereco()
            {
                Principal = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoPrincipal_FalseQuandoPossuiDoisEnderecoPrincipal()
        {
            var endereco1 = new Endereco()
            {
                Principal = true
            };

            var endereco2 = new Endereco()
            {
                Principal = true
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
