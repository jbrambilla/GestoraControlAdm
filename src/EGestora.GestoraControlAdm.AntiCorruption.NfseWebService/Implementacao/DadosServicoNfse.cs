using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class DadosServicoNfse : IDadosServicoNfse
    {
        public tcDadosServico GetDadosServico(NotaServico notaServico)
        {
            var dados = new tcDadosServico();
            dados.CodigoCnae = Convert.ToInt32(notaServico.Empresa.CnaeList.FirstOrDefault().Codigo.Replace("-", "").Replace("/", ""));
            dados.CodigoCnaeSpecified = true;
            dados.CodigoMunicipio = 3541406;
            dados.CodigoTributacaoMunicipio = "";
            dados.ItemListaServico = notaServico.Empresa.EnquadramentoServico.Codigo;
            dados.Discriminacao = notaServico.DiscriminacaoServico.Replace("\n", " ").Replace("\r", "").Trim();

            return dados;
        }

    }
}
