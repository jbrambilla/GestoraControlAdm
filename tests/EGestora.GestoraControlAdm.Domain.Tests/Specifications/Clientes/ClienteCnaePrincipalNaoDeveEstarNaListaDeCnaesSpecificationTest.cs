using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.Clientes
{
    [TestClass]
    public class ClienteCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecificationTest
    {
        [TestMethod]
        public void Cliente_CnaePrincipalForaDaListaDeCnaes_True()
        {
            var CnaeId1 = Guid.NewGuid();
            var CnaeId2 = Guid.NewGuid();
            var Cnae1 = new Cnae() { CnaeId = CnaeId1 };
            var Cnae2 = new Cnae() { CnaeId = CnaeId2 };
            var Cliente = new Cliente();
            Cliente.CnaeList.Add(Cnae1);
            Cliente.CnaeList.Add(Cnae2);
            Cliente.CnaeId = Guid.NewGuid();

            var specification = new ClienteCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();
            Assert.IsTrue(specification.IsSatisfiedBy(Cliente));
        }

        [TestMethod]
        public void Cliente_CnaePrincipalForaDaListaDeCnaes_False()
        {
            var CnaeId1 = Guid.NewGuid();
            var CnaeId2 = Guid.NewGuid();
            var Cnae1 = new Cnae() { CnaeId = CnaeId1 };
            var Cnae2 = new Cnae() { CnaeId = CnaeId2 };
            var Cliente = new Cliente();
            Cliente.CnaeList.Add(Cnae1);
            Cliente.CnaeList.Add(Cnae2);
            Cliente.CnaeId = CnaeId1;

            var specification = new ClienteCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();
            Assert.IsFalse(specification.IsSatisfiedBy(Cliente));
        }
    }
}
