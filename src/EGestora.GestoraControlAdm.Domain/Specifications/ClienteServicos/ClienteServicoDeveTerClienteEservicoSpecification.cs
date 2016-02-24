using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.ClienteServicos
{
    public class ClienteServicoDeveTerClienteEservicoSpecification : ISpecification<ClienteServico>
    {
        public bool IsSatisfiedBy(ClienteServico clienteServico)
        {
            return clienteServico.Cliente != null && clienteServico.Servico != null;
        }
    }
}
