using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Pessoas.PJ
{
    [TestClass]
    public class PessoaJuridicaDevePossuirCnpjUnicoSpecificationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void Pessoa_CnpjUnico_True_PessoaFisicaNull()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCnpj(Pessoa.PessoaJuridica.Cnpj)).Return(null);

            var specification = new PessoaJuridicaDevePossuirCnpjUnicoSpecification<Pessoa>(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_CnpjUnico_True_PessoaFisicaNotNull()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();

            var specification = new PessoaJuridicaDevePossuirCnpjUnicoSpecification<Pessoa>(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Pessoa));
        }

        [TestMethod]
        public void Pessoa_CnpjUnico_False_PessoaFisicaNull()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCnpj(Pessoa.PessoaJuridica.Cnpj)).Return(Pessoa);

            var specification = new PessoaJuridicaDevePossuirCnpjUnicoSpecification<Pessoa>(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(Pessoa));
        }

    }
}
