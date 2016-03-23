using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IDebitoAppService : IDisposable
    {
        DebitoViewModel Add(DebitoViewModel debitoViewModel);
        DebitoViewModel GetById(Guid id);
        IEnumerable<DebitoViewModel> GetAll();
        DebitoViewModel Update(DebitoViewModel debitoViewModel);
        void Remove(Guid id);

        IEnumerable<PessoaJuridicaViewModel> GetAllClientes();
    }
}
