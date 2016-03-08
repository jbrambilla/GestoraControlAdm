using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class DadosTomadorNfse : IDadosTomadorNfse
    {
        public tcDadosTomador GetDadosTomador(NotaServico notaServico)
        {
            var tomador = new tcDadosTomador();
            tomador.RazaoSocial = notaServico.Cliente.PessoaJuridica.RazaoSocial;
            tomador.IdentificacaoTomador = new tcIdentificacaoTomador();
            tomador.IdentificacaoTomador.CpfCnpj = new tcCpfCnpj();
            tomador.IdentificacaoTomador.CpfCnpj.Item = notaServico.Cliente.PessoaJuridica.Cnpj;
            tomador.IdentificacaoTomador.CpfCnpj.ItemElementName = ItemChoiceType.Cnpj;
            tomador.IdentificacaoTomador.InscricaoMunicipal = notaServico.Cliente.PessoaJuridica.InscricaoMunicipal;

            return tomador;
        }

    }
}
