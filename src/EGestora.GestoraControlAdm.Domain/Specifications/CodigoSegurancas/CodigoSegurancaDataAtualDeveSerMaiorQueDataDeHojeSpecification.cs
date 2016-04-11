using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas
{
    public class CodigoSegurancaDataAtualDeveSerMaiorQueDataDeHojeSpecification : ISpecification<CodigoSeguranca>
    {
        public bool IsSatisfiedBy(CodigoSeguranca codigoSeguranca)
        {
            return codigoSeguranca.DataAtual.Date.CompareTo(DateTime.Now.Date) >= 0;
        }
    }
}
