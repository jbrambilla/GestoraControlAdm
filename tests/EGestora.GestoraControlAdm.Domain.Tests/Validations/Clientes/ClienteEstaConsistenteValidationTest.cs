using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Clientes
{
    [TestClass]
    public class ClienteEstaConsistenteValidationTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void Cliente_Consistente_True()
        {
            var pessoaJuridica = new PessoaJuridica();
            pessoaJuridica.Cnpj = "34625757000192";
            pessoaJuridica.EnderecoList.Add(new Endereco());

            Cliente = new Cliente() { PessoaJuridica = pessoaJuridica };

            var validation = new ClienteEstaConsistenteValidation();
            Assert.IsTrue(validation.Validate(Cliente).IsValid);
        }

        [TestMethod]
        public void Cliente_Consistente_Cnpj_Email_False()
        {
            var pessoaJuridica = new PessoaJuridica();
            pessoaJuridica.Cnpj = "34625757000111";

            Cliente = new Cliente() { PessoaJuridica = pessoaJuridica };

            var validation = new ClienteEstaConsistenteValidation();
            var result = validation.Validate(Cliente);

            Assert.IsFalse(validation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente informou um CNPJ inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente precisa possuir um Endereço."));
        }

        [TestMethod]
        public void Cliente_Consistente_PessoaJuridica_False()
        {
            Cliente = new Cliente();

            var validation = new ClienteEstaConsistenteValidation();
            var result = validation.Validate(Cliente);

            Assert.IsFalse(validation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente precisa possuir uma Pessoa Jurídica."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente informou um CNPJ inválido."));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Cliente precisa possuir um Endereço."));
        }
    }
}
