using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.ClienteServicos;

namespace EGestora.GestoraControlAdm.Domain.Validations.ClienteServicos
{
    public class ClienteServicoEstaConsistenteValidation : Validator<ClienteServico>
    {
        public ClienteServicoEstaConsistenteValidation()
        {
            var clienteEservico = new ClienteServicoDeveTerClienteEservicoSpecification();

            base.Add("clienteEservico", new Rule<ClienteServico>(clienteEservico, "É necessário selecionar um cliente e um serviço."));
        }
    }
}
