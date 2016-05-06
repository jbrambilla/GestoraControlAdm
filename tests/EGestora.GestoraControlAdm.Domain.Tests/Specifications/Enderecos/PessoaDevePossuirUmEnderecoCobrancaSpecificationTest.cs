using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Enderecos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Enderecos
{
    [TestClass]
    public class PessoaDevePossuirUmEnderecoCobrancaSpecificationTest
    {
        [TestMethod]
        public void Pessoa_EnderecoCobranca_TrueQuandoPossuiApenasUmEnderecoCobranca()
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Cobranca = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Cobranca = false
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(enderecoSendoCadastrado));
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
                Cobranca = false
            };

            var Pessoa = new Pessoa();
            Pessoa.EnderecoList.Add(endereco1);
            Pessoa.EnderecoList.Add(endereco2);

            var enderecoSendoCadastrado = new Endereco()
            {
                PessoaId = Pessoa.PessoaId,
                Cobranca = true
            };

            var stubRepo = MockRepository.GenerateStub<IEnderecoRepository>();
            stubRepo.Stub(s => s.GetAllByPessoaId(Pessoa.PessoaId)).Return(Pessoa.EnderecoList);

            var specification = new PessoaDevePossuirUmEnderecoCobrancaSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(enderecoSendoCadastrado));
        }
    }
}
