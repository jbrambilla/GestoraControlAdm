using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.AuditControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.AuditControllers
{
    [TestClass]
    public class AuditControllerDevePossuirControllerUnicoSpecificationTest
    {
        [TestMethod]
        public void AuditController_ControllerUnico_True()
        {
            var AuditControllerReturn = new AuditController() { ControllerName = "Clientes" };
            var AuditControllerList = new List<AuditController>();
            AuditControllerList.Add(AuditControllerReturn);

            var AuditController = new AuditController() { ControllerName = "Funcionarios" };

            var stubRepo = MockRepository.GenerateStub<IAuditControllerRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(AuditControllerList);

            var specification = new AuditControllerDevePossuirControllerUnicoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(AuditController));
        }

        [TestMethod]
        public void AuditController_ControllerUnico_False()
        {
            var AuditControllerReturn = new AuditController() { ControllerName = "Clientes" };
            var AuditControllerList = new List<AuditController>();
            AuditControllerList.Add(AuditControllerReturn);

            var AuditController = new AuditController() { ControllerName = "Clientes" };

            var stubRepo = MockRepository.GenerateStub<IAuditControllerRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(AuditControllerList);

            var specification = new AuditControllerDevePossuirControllerUnicoSpecification(stubRepo);
            Assert.IsFalse(specification.IsSatisfiedBy(AuditController));
        }
    }
}
