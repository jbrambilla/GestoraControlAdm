using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Enderecos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Enderecos
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoEntregaSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoEntrega_TrueQuandoPossuiApenasUmEnderecoEntrega()
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Entrega = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Entrega = false
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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
                Entrega = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Entrega = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoEntregaSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(enderecoSendoCadastrado));
        }
    }
}
