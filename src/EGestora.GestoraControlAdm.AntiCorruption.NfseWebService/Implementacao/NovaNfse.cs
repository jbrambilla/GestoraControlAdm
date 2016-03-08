using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class NovaNfse : INovaNfse
    {
        public tcInfNovaNfse GetNovaNfse(NotaServico notaServico)
        {
            var informacoes = new tcInfNovaNfse();
            informacoes.OutrasInformacoes = notaServico.IssRetido ? "ISS retido na fonte com base na LEI COMPLEMENTAR 199/2015" : "";
            informacoes.Competencia = notaServico.CriadoEm;
            informacoes.Status = 1;
            informacoes.NaturezaOperacao = Convert.ToSByte(notaServico.Empresa.NaturezaOperacao.Codigo);
            informacoes.RegimeEspecialTributacao = Convert.ToSByte(notaServico.Empresa.RegimeTributacao.Codigo); //regime de tributação especial
            informacoes.RegimeEspecialTributacaoSpecified = (notaServico.Empresa.RegimeTributacao.Codigo > 0);
            informacoes.OptanteSimplesNacional = Convert.ToSByte(notaServico.Empresa.OptanteSimplesNacional);
            informacoes.IncentivadorCultural = 2; //não
            informacoes.OutrasInformacoes = (String.IsNullOrEmpty(notaServico.OutrasInformacoes)) ? "" : notaServico.OutrasInformacoes.Replace("\n", " ").Replace("\r", "").Trim();

            return informacoes;            
        }

    }
}
