using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface ILoteFaturamentoAppService : IDisposable
    {
        LoteFaturamentoViewModel Add(LoteFaturamentoViewModel loteFaturamentoViewModel);
        LoteFaturamentoViewModel GetById(Guid id);
        IEnumerable<LoteFaturamentoViewModel> GetAll();
        LoteFaturamentoViewModel Update(LoteFaturamentoViewModel loteFaturamentoViewModel);
        void Remove(Guid id);
    }
}
