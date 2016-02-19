using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Pessoas
{
    [TestClass]
    public class PessoaEstaConsistenteValidationTest
    {
        [TestMethod]
        public void Pessoa_PessoaFisicaNull_PessoaJuridicaNotNull_Consistente_True()
        {
            var Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000192", RazaoSocial = "DOLEMAR ABRANTES", NomeFantasia = "FUnilaria" } };
            Pessoa.EnderecoList.Add(new Endereco());

            var validation = new PessoaEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void Pessoa_PessoaFisicaNull_PessoaJuridicaNotNull_Consistente_False()
        {
            var Pessoa = new Pessoa() { PessoaJuridica = new PessoaJuridica() { Cnpj = "34625757000111" } };

            var validation = new PessoaEstaConsistenteValidation();
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O CNPJ informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "É necessário possuir um Endereço para o cadastro."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O CPF informado é inválido."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "A Entidade precisa ser Física ou Jurídica."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Nome é obrigatório."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Razão Social é obrigatório."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Nome Fantasia é obrigatório."));
        }

        [TestMethod]
        public void Pessoa_PessoaFisicaNotNull_PessoaJuridicaNull_Consistente_True()
        {
            var Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "52967264644", Nome = "Mathias" } };
            Pessoa.EnderecoList.Add(new Endereco());

            var validation = new PessoaEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(Pessoa).IsValid);
        }

        [TestMethod]
        public void Pessoa_PessoaFisicaNotNull_PessoaJuridicaNull_Consistente_False()
        {
            var Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica() { Cpf = "52967264111" } };

            var validation = new PessoaEstaConsistenteValidation();
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O CNPJ informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "É necessário possuir um Endereço para o cadastro."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O CPF informado é inválido."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "A Entidade precisa ser Física ou Jurídica."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Nome é obrigatório."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Razão Social é obrigatório."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Nome Fantasia é obrigatório."));
        }

        [TestMethod]
        public void Pessoa_PessoaFisicaNull_PessoaJuridicaNull_Consistente_False()
        {
            var Pessoa = new Pessoa();

            var validation = new PessoaEstaConsistenteValidation();
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O CNPJ informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "É necessário possuir um Endereço para o cadastro."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O CPF informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "A Entidade precisa ser Física ou Jurídica."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Nome é obrigatório."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Razão Social é obrigatório."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "O campo Nome Fantasia é obrigatório."));
        }

        [TestMethod]
        public void Pessoa_PessoaFisicatNotNull_PessoaJuridicaNotNull_Consistente_False()
        {
            var Pessoa = new Pessoa() { PessoaFisica = new PessoaFisica(), PessoaJuridica = new PessoaJuridica() };

            var validation = new PessoaEstaConsistenteValidation();
            var result = validation.Validate(Pessoa);

            Assert.IsFalse(validation.Validate(Pessoa).IsValid);
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O CNPJ informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "É necessário possuir um Endereço para o cadastro."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O CPF informado é inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "A Entidade precisa ser Física ou Jurídica."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Nome é obrigatório."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Razão Social é obrigatório."));
            Assert.IsFalse(result.Erros.Any(e => e.Message == "O campo Nome Fantasia é obrigatório."));
        }
    }
}
