using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoCobrancaSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoCobranca_TrueQuandoPossuiApenasUmEnderecoCobranca()
        {
            var endereco1 = new Endereco()
            {
                Cobranca = true
            };

            var endereco2 = new Endereco()
            {
                Cobranca = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoCobranca_TrueQuandoPossuiNenhumEnderecoCobranca()
        {
            var endereco1 = new Endereco()
            {
                Cobranca = false
            };

            var endereco2 = new Endereco()
            {
                Cobranca = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoCobranca_FalseQuandoPossuiDoisEnderecoCobranca()
        {
            var endereco1 = new Endereco()
            {
                Cobranca = true
            };

            var endereco2 = new Endereco()
            {
                Cobranca = true
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
