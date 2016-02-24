using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IClienteServicoService : IDisposable
    {
        ClienteServico Add(ClienteServico clienteServico);
        ClienteServico GetById(Guid id);
        IEnumerable<ClienteServico> GetAll();
        ClienteServico Update(ClienteServico clienteServico);
        void Remove(Guid id);
    }
}
