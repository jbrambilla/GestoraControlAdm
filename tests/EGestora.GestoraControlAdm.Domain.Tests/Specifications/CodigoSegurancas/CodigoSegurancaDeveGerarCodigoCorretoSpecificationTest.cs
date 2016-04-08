using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Services;
using EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
namespace EGestora.GestoraControlAdm.Domain.Tests.Specifications.CodigoSegurancas
{
    [TestClass]
    public class CodigoSegurancaDeveGerarCodigoCorretoSpecificationTest
    {
        [TestMethod]
        public void CodigoSeguranca_GerarCodigoCorreto_True()
        {
            var codigoSeguranca = new CodigoSeguranca() 
            { 
                DataAtual = DateTime.Now,
                DataTrava = DateTime.Now.AddDays(30),
                Codigo = "111111111111"
            };

            var stubRepo = MockRepository.GenerateStub<ICodigoSegurancaRepository>();
            stubRepo.Stub(s => s.GerarCodigo(codigoSeguranca));

            var specification = new CodigoSegurancaDeveGerarCodigoCorretoSpecification(stubRepo);
            Assert.IsTrue(specification.IsSatisfiedBy(codigoSeguranca));
        }

        [TestMethod]
        public void CodigoSeguranca_GerarCodigoCorreto_False()
        {

        }
    }
}

