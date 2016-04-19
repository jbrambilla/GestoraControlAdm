using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Empresas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Empresas
{
    [TestClass]
    public class EmpresaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecificationTest
    {
        [TestMethod]
        public void Empresa_CnaePrincipalForaDaListaDeCnaes_True()
        {
            var CnaeId1 = Guid.NewGuid();
            var CnaeId2 = Guid.NewGuid();
            var Cnae1 = new Cnae() { CnaeId = CnaeId1 };
            var Cnae2 = new Cnae() { CnaeId = CnaeId2 };
            var Empresa = new Empresa();
            Empresa.CnaeList.Add(Cnae1);
            Empresa.CnaeList.Add(Cnae2);
            Empresa.CnaeId = Guid.NewGuid();

            var specification = new EmpresaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Empresa));
        }

        [TestMethod]
        public void Empresa_CnaePrincipalForaDaListaDeCnaes_False()
        {
            var CnaeId1 = Guid.NewGuid();
            var CnaeId2 = Guid.NewGuid();
            var Cnae1 = new Cnae() { CnaeId = CnaeId1 };
            var Cnae2 = new Cnae() { CnaeId = CnaeId2 };
            var Empresa = new Empresa();
            Empresa.CnaeList.Add(Cnae1);
            Empresa.CnaeList.Add(Cnae2);
            Empresa.CnaeId = CnaeId1;

            var specification = new EmpresaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Empresa));
        }
    }
}

