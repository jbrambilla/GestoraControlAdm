using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface ICnaeAppService : IDisposable
    {
        CnaeViewModel Add(CnaeViewModel cnaeViewModel);
        CnaeViewModel GetById(Guid id);
        IEnumerable<CnaeViewModel> GetAll();
        CnaeViewModel Update(CnaeViewModel cnaeViewModel);
        void Remove(Guid id);
    }
}
