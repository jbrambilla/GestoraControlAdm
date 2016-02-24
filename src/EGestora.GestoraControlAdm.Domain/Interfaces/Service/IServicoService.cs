using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IServicoService : IDisposable
    {
        Servico Add(Servico servico);
        Servico GetById(Guid id);
        IEnumerable<Servico> GetAll();
        Cnae Update(Servico servico);
        void Remove(Guid id);
    }
}
