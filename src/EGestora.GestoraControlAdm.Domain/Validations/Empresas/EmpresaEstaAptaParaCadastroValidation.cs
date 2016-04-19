using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Empresas;

namespace EGestora.GestoraControlAdm.Domain.Validations.Empresas
{
    public class EmpresaEstaAptaParaCadastroValidation : Validator<Empresa>
    {
        public EmpresaEstaAptaParaCadastroValidation(IEmpresaRepository empresaRepository)
        {
            var registroAtivoUnico = new EmpresaDeveTerRegistroAtivoUnicoSpecification(empresaRepository);
            var cnaePrincipal = new EmpresaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();

            base.Add("registroAtivoUnico", new Rule<Empresa>(registroAtivoUnico, "Só é permitido uma empresa ativa no sistema."));
            base.Add("cnaePrincipal", new Rule<Empresa>(cnaePrincipal, "O Cnae Principal não pode estar na lista de Cnaes."));
        }
    }
}
