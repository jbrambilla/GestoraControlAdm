using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IEmpresaService : IDisposable
    {
        Empresa Add(Empresa empresa);
        Empresa GetById(Guid id);
        Empresa GetEmpresaAtiva();
        IEnumerable<Empresa> GetAll();
        Empresa Update(Empresa empresa);
        void Remove(Guid id);

        IEnumerable<RegimeApuracao> GetAllRegimeApuracao();

        IEnumerable<NaturezaOperacao> GetAllNaturezaOperacao();

        IEnumerable<RegimeTributacao> GetAllRegimeTributacao();

        IEnumerable<EnquadramentoServico> GetAllEnquadramentoServico();
    }
}
