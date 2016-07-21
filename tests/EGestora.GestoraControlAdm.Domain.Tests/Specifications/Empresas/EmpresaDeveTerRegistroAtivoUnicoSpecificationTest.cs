using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Empresas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Empresas
{
    [TestClass]
    public class EmpresaDeveTerRegistroAtivoUnicoSpecificationTest
    {
        public Empresa Empresa { get; set; }

        [TestMethod]
        public void Empresa_RegistroAtivoUnico_True()
        {
            Empresa = new Empresa();

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(null);

            var specification = new EmpresaDeveTerRegistroAtivoUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Empresa));
        }

        [TestMethod]
        public void Empresa_RegistroAtivoUnico_TrueWhenThereIsListButNotActiveEmpresas()
        {
            Empresa = new Empresa();
            var list = new List<Empresa>() { new Empresa() { Pessoa = new Pessoa() {Ativo = false} } };

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(list);

            var specification = new EmpresaDeveTerRegistroAtivoUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(Empresa));
        }

        [TestMethod]
        public void Empresa_RegistroAtivoUnico_False()
        {
            Empresa = new Empresa();
            var list = new List<Empresa>() { new Empresa() { Pessoa = new Pessoa() { Ativo = true } } };

            var stubRepo = MockRepository.GenerateStub<IEmpresaRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(list);

            var specification = new EmpresaDeveTerRegistroAtivoUnicoSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(Empresa));
        }

    }
}
