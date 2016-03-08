using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class CredencialNfse : ICredencialNfse
    {
        public ddDuasStrings GetCredencial(NotaServico notaServico)
        {
            return new ddDuasStrings() {
                P1 = notaServico.Empresa.LoginIss, 
                P2 = notaServico.Empresa.SenhaIss 
            };
        }

    }
}
