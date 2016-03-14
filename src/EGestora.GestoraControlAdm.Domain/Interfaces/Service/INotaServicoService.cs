using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface INotaServicoService : IDisposable
    {
        NotaServico Add(NotaServico notaServico);
        NotaServico GetById(Guid id);
        IEnumerable<NotaServico> GetAll();
        NotaServico Update(NotaServico notaServico);
        void Remove(Guid id);

        IEnumerable<PessoaJuridica> GetAllClientes();
        Cliente ObterClientePorId(Guid id);

        Empresa GetEmpresaAtiva();
    }
}
