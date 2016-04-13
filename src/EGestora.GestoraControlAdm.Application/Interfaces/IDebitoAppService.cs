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
        int GetTotalRecords();
        IEnumerable<DebitoViewModel> GetAllToGrid(int skip, int take);
        void Baixar(Guid id, DateTime DataBaixa);

        IEnumerable<PessoaJuridicaViewModel> GetAllClientes();

        string GetBoletoHtml(BoletoViewModel boleto);
        byte[] GetBoletoBytes(BoletoViewModel boleto);

        BoletoViewModel GetBoletoById(Guid id);
    }
}
