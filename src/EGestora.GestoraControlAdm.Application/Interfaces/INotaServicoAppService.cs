using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface INotaServicoAppService : IDisposable
    {
        NotaServicoDebitoViewModel Add(NotaServicoDebitoViewModel notaServicoDebitoViewModel);
        NotaServicoViewModel GetById(Guid id);
        IEnumerable<NotaServicoViewModel> GetAll();
        NotaServicoViewModel Update(NotaServicoViewModel notaServicoViewModel);
        void Remove(Guid id);

        IEnumerable<PessoaJuridicaViewModel> GetAllClientes();
        ClienteViewModel ObterClientePorId(Guid id);

        EmpresaViewModel GetEmpresaAtiva();

        //DebitoViewModel AddDebito(DebitoViewModel debitoViewModel);
    }
}
