using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaViewModel Add(EmpresaViewModel empresaViewModel);
        EmpresaViewModel GetById(Guid id);
        EmpresaViewModel GetEmpresaAtiva();
        IEnumerable<EmpresaViewModel> GetAll();
        EmpresaViewModel Update(EmpresaViewModel empresaViewModel);
        void Remove(Guid id);

        IEnumerable<RegimeApuracaoViewModel> GetAllRegimeApuracao();

        IEnumerable<NaturezaOperacaoViewModel> GetAllNaturezaOperacao();

        IEnumerable<RegimeTributacaoViewModel> GetAllRegimeTributacao();

        IEnumerable<EnquadramentoServicoViewModel> GetAllEnquadramentoServico();
    }
}
