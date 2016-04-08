using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas
{
    public class CodigoSegurancaDataAtualDeveSerMaiorQueDataDeHojeSpecification : ISpecification<CodigoSeguranca>
    {
        public bool IsSatisfiedBy(CodigoSeguranca codigoSeguranca)
        {
            return codigoSeguranca.DataAtual.CompareTo(DateTime.Now) > 0;
        }
    }
}
