using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class ContatoTomadorNfse : IContatoTomadorNfse
    {
        public tcContato GetContatoTomador(NotaServico notaServico)
        {
            var contato = new tcContato();
            contato.Email = notaServico.Cliente.Email;
            contato.Telefone = "18981451508";

            return contato;
        }

    }
}
