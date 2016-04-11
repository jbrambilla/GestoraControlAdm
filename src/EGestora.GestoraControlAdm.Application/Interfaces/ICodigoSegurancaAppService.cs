using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface ICodigoSegurancaAppService : IDisposable
    {
        CodigoSegurancaViewModel Add(CodigoSegurancaViewModel codigoSegurancaViewModel);
        CodigoSegurancaViewModel GetById(Guid id);
        IEnumerable<CodigoSegurancaViewModel> GetAll();
        CodigoSegurancaViewModel Update(CodigoSegurancaViewModel codigoSegurancaViewModel);
        void Remove(Guid id);

        IEnumerable<PessoaJuridicaViewModel> GetAllClientes();
    }
}
