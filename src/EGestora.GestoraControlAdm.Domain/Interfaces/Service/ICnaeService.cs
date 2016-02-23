using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface ICnaeService : IDisposable
    {
        Cnae Add(Cnae cnae);
        Cnae GetById(Guid id);
        IEnumerable<Cnae> GetAll();
        Cnae Update(Cnae cnae);
        void Remove(Guid id);
    }
}
