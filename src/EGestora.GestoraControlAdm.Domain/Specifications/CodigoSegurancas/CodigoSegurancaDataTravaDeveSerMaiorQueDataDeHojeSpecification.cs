using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas
{
    public class CodigoSegurancaDataTravaDeveSerMaiorQueDataDeHojeSpecification : ISpecification<CodigoSeguranca>
    {
        public bool IsSatisfiedBy(CodigoSeguranca codigoSeguranca)
        {
            return codigoSeguranca.DataTrava.Date.CompareTo(DateTime.Now.Date) > 0;
        }
    }
}
