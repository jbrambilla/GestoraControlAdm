using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Validations.AuditControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Tests.Validations.AuditControllers
{
    [TestClass]
    public class AuditControllerEstaAptoParaCadastroValidationTest
    {
        [TestMethod]
        public void AuditController_AptoParaCadastro_True()
        {

            var AuditControllerReturn = new AuditController() { ControllerName = "Clientes" };
            var AuditControllerList = new List<AuditController>();
            AuditControllerList.Add(AuditControllerReturn);

            var AuditController = new AuditController() { ControllerName = "Funcionarios" };

            var stubRepo = MockRepository.GenerateStub<IAuditControllerRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(AuditControllerList);

            var validation = new AuditControllerEstaAptoParaCadastroValidation(stubRepo);

            Assert.IsTrue(validation.Validate(AuditController).IsValid);

        }

        [TestMethod]
        public void AuditController_AptoParaCadastro_False()
        {

            var AuditControllerReturn = new AuditController() { ControllerName = "Clientes" };
            var AuditControllerList = new List<AuditController>();
            AuditControllerList.Add(AuditControllerReturn);

            var AuditController = new AuditController() { ControllerName = "Clientes" };

            var stubRepo = MockRepository.GenerateStub<IAuditControllerRepository>();
            stubRepo.Stub(s => s.GetAll()).Return(AuditControllerList);

            var validation = new AuditControllerEstaAptoParaCadastroValidation(stubRepo);
            var result = validation.Validate(AuditController);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Este Controller já existe na lista de Auditoria."));
        }
    }
}
