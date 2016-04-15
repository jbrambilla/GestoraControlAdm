using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IDebitoRepository : IRepositoryBase<Debito>
    {
        IEnumerable<Debito> GetAllToGrid(int skip, int take);
        void GerarBoletos(Debito debito);
    }
}
