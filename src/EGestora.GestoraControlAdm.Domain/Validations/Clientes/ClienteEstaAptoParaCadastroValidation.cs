using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Clientes;

namespace EGestora.GestoraControlAdm.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteEstaAptoParaCadastroValidation()
        {
            var cnaePrincipal = new ClienteCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification();

            base.Add("cnaePrincipal", new Rule<Cliente>(cnaePrincipal, "O Cnae Principal não pode estar na lista de Cnaes."));
        }
    }
}
