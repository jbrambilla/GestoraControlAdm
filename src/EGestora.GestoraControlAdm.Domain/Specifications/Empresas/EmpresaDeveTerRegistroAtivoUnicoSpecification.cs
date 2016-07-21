using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System.Linq;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Empresas
{
    public class EmpresaDeveTerRegistroAtivoUnicoSpecification : ISpecification<Empresa>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaDeveTerRegistroAtivoUnicoSpecification(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public bool IsSatisfiedBy(Empresa empresa)
        {
            var empresas = _empresaRepository.GetAll();

            if (empresas == null)
            {
                return true;
            }
            return !empresas.Any(e => e.Pessoa.Ativo);
        }
    }
}
