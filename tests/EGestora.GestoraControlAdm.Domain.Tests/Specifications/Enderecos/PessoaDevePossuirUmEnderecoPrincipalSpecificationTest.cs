using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Enderecos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Enderecos
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoPrincipalSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoPrincipal_TrueQuandoPossuiApenasUmEnderecoPrincipal()
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Principal = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Principal = false
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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
                Principal = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Principal = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoPrincipalSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(enderecoSendoCadastrado));
        }
    }
}
