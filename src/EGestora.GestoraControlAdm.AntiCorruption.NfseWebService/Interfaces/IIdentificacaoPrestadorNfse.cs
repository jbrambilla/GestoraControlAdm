using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces
{
    public interface IIdentificacaoPrestadorNfse
    {
        tcIdentificacaoPrestador GetIdentificacaoPrestador(NotaServico notaServico);
    }
}
