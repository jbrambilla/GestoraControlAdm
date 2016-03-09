using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface ILoteFaturamentoService : IDisposable
    {
        LoteFaturamento Add(LoteFaturamento loteFaturamento);
        LoteFaturamento GetById(Guid id);
        IEnumerable<LoteFaturamento> GetAll();
        LoteFaturamento Update(LoteFaturamento loteFaturamento);
        void Remove(Guid id);
    }
}
