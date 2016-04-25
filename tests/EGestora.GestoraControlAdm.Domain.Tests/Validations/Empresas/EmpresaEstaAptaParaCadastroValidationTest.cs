using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Validations.Empresas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.Empresas
{
    [TestClass]
    public class EmpresaEstaAptaParaCadastroValidationTest
    {
        public Empresa Empresa { get; set; }

        [TestMethod]
        public void Empresa_AptoQuandoNaoExisteEmpresaCadastrada_True()
        {
            Empresa = new Empresa();

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(null);

            var validation = new EmpresaEstaAptaParaCadastroValidation(stubRepo);

            Assert.IsTrue(validation.Validate(Empresa).IsValid);
        }

        [TestMethod]
        public void Empresa_AptoQuandoExisteEmpresaCadastrada_True()
        {
            Empresa = new Empresa();
            var list = new List<Empresa>() { new Empresa() { Ativo = false } };

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(list);

            var validation = new EmpresaEstaAptaParaCadastroValidation(stubRepo);

            Assert.IsTrue(validation.Validate(Empresa).IsValid);
        }

        [TestMethod]
        public void Empresa_AptoQuandoExisteEmpresaAtiva_False()
        {
            Empresa = new Empresa();
            var list = new List<Empresa>() { new Empresa() { Ativo = true } };

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(list);

            var validation = new EmpresaEstaAptaParaCadastroValidation(stubRepo);
            var result = validation.Validate(Empresa);

            Assert.IsFalse(validation.Validate(Empresa).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Só é permitido uma empresa ativa no sistema."));
        }
    }
}
