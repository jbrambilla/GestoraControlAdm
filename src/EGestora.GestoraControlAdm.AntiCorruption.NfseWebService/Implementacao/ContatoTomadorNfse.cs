using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class ContatoTomadorNfse : IContatoTomadorNfse
    {
        public tcContato GetContatoTomador(NotaServico notaServico)
        {
            var contatos = notaServico.Cliente.Pessoa.ContatoList;
            var email = contatos.Any(c => c.TipoContato.Nome.Contains("mail")) ? contatos.FirstOrDefault(c => c.TipoContato.Nome.Contains("mail")).InformacaoContato : "email@teste.com";
            
            var contato = new tcContato();
            contato.Email = email;
            contato.Telefone = "18981451508";

            return contato;
        }

    }
}
