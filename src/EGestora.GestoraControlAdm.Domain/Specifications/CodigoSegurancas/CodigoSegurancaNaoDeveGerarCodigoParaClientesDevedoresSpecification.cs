using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas
{
    public class CodigoSegurancaNaoDeveGerarCodigoParaClientesDevedoresSpecification : ISpecification<CodigoSeguranca>
    {
        public bool IsSatisfiedBy(CodigoSeguranca codigoSeguranca)
        {
            var ret = !codigoSeguranca.Cliente.DebitoList.Any(d => !d.IsPago() && d.IsVencido() );
            return ret;
        }
    }
}
