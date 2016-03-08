using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class IdentificacaoPrestadorNfse : IIdentificacaoPrestadorNfse
    {
        public tcIdentificacaoPrestador GetIdentificacaoPrestador(NotaServico notaServico)
        {
            var prestador = new tcIdentificacaoPrestador();
            prestador.Cnpj = notaServico.Empresa.PessoaJuridica.Cnpj;
            prestador.InscricaoMunicipal = notaServico.Empresa.PessoaJuridica.InscricaoMunicipal;

            return prestador;
        }

    }
}
