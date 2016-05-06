using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoEntregaSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoEntrega_TrueQuandoPossuiApenasUmEnderecoEntrega()
        {
            var endereco1 = new Endereco()
            {
                Entrega = true
            };

            var endereco2 = new Endereco()
            {
                Entrega = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoEntrega_TrueQuandoPossuiNenhumEnderecoEntrega()
        {
            var endereco1 = new Endereco()
            {
                Entrega = false
            };

            var endereco2 = new Endereco()
            {
                Entrega = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_EnderecoEntrega_FalseQuandoPossuiDoisEnderecoEntrega()
        {
            var endereco1 = new Endereco()
            {
                Entrega = true
            };

            var endereco2 = new Endereco()
            {
                Entrega = true
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
