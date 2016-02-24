using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IServicoAppService : IDisposable
    {
        ServicoViewModel Add(ServicoViewModel servicoViewModel);
        ServicoViewModel GetById(Guid id);
        IEnumerable<ServicoViewModel> GetAll();
        ServicoViewModel Update(ServicoViewModel servicoViewModel);
        void Remove(Guid id);
    }
}
