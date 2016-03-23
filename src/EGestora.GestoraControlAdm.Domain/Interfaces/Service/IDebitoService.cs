using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IDebitoService : IDisposable
    {
        Debito Add(Debito debito);
        Debito GetById(Guid id);
        IEnumerable<Debito> GetAll();
        Debito Update(Debito debito);
        void Remove(Guid id);

        IEnumerable<PessoaJuridica> GetAllClientes();

        void GerarBoletoParaDebito(Debito debito);

        string GetBoletoHtml(Boleto boleto);
        byte[] GetBoletoBytes(Boleto boleto);
    }
}
