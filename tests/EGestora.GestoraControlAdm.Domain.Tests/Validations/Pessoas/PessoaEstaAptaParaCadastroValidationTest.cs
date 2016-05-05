using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Pessoas
{
    [TestClass]
    public class PessoaEstaAptaParaCadastroValidationTest
    {
        public Pessoa Pessoa { get; set; }

        [TestMethod]
        public void PessoaJuridica_Apto_PessoaFisicaNull_True()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCnpj(Pessoa.PessoaJuridica.Cnpj)).Return(null);

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);

            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void PessoaJuridica_Apto_PessoaFisicaNotNull_True()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);

            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void PessoaJuridica_Apto_False()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCnpj(Pessoa.PessoaJuridica.Cnpj)).Return(Pessoa);

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Este CNPJ já está cadastrado."));
        }

        [TestMethod]
        public void PessoaFisica_Apto_PessoaJuridicaNull_True()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "52967264644" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCpf(Pessoa.PessoaFisica.Cpf)).Return(null);

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);

            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void PessoaFisica_Apto_PessoaJuridicaNotNull_True()
        {
            Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);

            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void PessoaFisica_Apto_False()
        {
            Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "52967264111" } };

            var stubRepo = MockRepository.GenerateStub<IPessoaComplexaRepository<Pessoa>>();
            stubRepo.Stub(s => s.GetByCpf(Pessoa.PessoaFisica.Cpf)).Return(Pessoa);

            var validation = new PessoaEstaAptaParaCadastroValidation<Pessoa>(stubRepo);
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Este CPF já está cadastrado."));
        }
    }
}
