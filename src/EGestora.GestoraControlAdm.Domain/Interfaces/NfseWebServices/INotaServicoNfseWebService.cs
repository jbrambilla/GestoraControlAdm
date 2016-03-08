using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices
{
    public interface INotaServicoNfseWebService
    {
        NotaServico Gerar(NotaServico notaServico);
        NotaServico Cancelar(NotaServico notaServico);
        NotaServico ConsultarPorRps(string rps);
    }
}
