using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface INotaServicoAppService : IDisposable
    {
        NotaServicoViewModel Add(NotaServicoViewModel notaServicoViewModel);
        NotaServicoViewModel GetById(Guid id);
        IEnumerable<NotaServicoViewModel> GetAll();
        NotaServicoViewModel Update(NotaServicoViewModel notaServicoViewModel);
        void Remove(Guid id);

        IEnumerable<PessoaJuridicaViewModel> GetAllClientes();
        ClienteViewModel ObterClientePorId(Guid id);

        EmpresaViewModel GetEmpresaAtiva();
    }
}
