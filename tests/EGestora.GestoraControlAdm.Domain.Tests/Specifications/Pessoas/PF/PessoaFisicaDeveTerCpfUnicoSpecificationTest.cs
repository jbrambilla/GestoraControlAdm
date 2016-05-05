using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas.PF
{
    [TestClass]
    public class PessoaFisicaDeveTerCpfUnicoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_CpfUnico_True_PessoaJuridicaNull()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "52967264644" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaRepository>();
            stubRepo.Stub(s => s.GetByCpf(Pessoa.PessoaFisica.Cpf)).Return(null);

            var specification = new PessoaFisicaDevePossuirCpfUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_CpfUnico_True_PessoaJuridicaNotNull()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() };

            var stubRepo = MockRepository.GenerateStub<IPessoaRepository>();

            var specification = new PessoaFisicaDevePossuirCpfUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_CpfUnico_False_PessoaJuridicaNull()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaRepository>();
            stubRepo.Stub(s => s.GetByCpf(Pessoa.PessoaFisica.Cpf)).Return(Pessoa);

            var specification = new PessoaFisicaDevePossuirCpfUnicoSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }
    }
}
