using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class ValoresServicoNfse : IValoresServicoNfse
    {
        public tcValores GetValoresServico(NotaServico notaServico)
        {
            var valores = new tcValores();
            valores.ValorServicos = notaServico.ValorTotal;
            valores.Aliquota = notaServico.Aliquota;
            valores.AliquotaSpecified = (notaServico.Aliquota > 0);
            valores.BaseCalculo = notaServico.BaseCalculo;
            valores.BaseCalculoSpecified = (notaServico.BaseCalculo > 0);
            valores.ValorIss = notaServico.ValorISS;
            valores.ValorIssSpecified = (notaServico.ValorISS > 0);
            valores.ValorLiquidoNfse = notaServico.ValorLiquido;
            valores.ValorLiquidoNfseSpecified = true;
            valores.IssRetido = 2;

            /*gestoraNFSe.Aliquota = gestoraNFSe.NFSe.InformacaoNfse.Servico.Valores.Aliquota;
            gestoraNFSe.BaseCalculo = gestoraNFSe.NFSe.InformacaoNfse.Servico.Valores.BaseCalculo;
            gestoraNFSe.ValorISS = gestoraNFSe.NFSe.InformacaoNfse.Servico.Valores.ValorIss;
            gestoraNFSe.Natu
             * reza = Nat_Emp;
            gestoraNFSe.Servico = Servico_Emp;
            gestoraNFSe.Reducao = Convert.ToDecimal(reducao);*/

            valores.ValorIssRetido = new decimal(0.0);
            valores.ValorIssRetidoSpecified = false;
            valores.DescontoCondicionado = new decimal(0.0);
            valores.DescontoCondicionadoSpecified = false;
            valores.DescontoIncondicionado = new decimal(0.0);
            valores.DescontoIncondicionadoSpecified = false;
            valores.OutrasRetencoes = new decimal(0.0);
            valores.OutrasRetencoesSpecified = false;
            valores.ValorCofins = new decimal(0.0);
            valores.ValorCofinsSpecified = false;
            valores.ValorPis = new decimal(0.0);
            valores.ValorPisSpecified = false;
            valores.ValorInss = new decimal(0.0);
            valores.ValorInssSpecified = false;
            valores.ValorIr = new decimal(0.0);
            valores.ValorIrSpecified = false;
            valores.ValorDeducoes = notaServico.ValorDeducoes;
            valores.ValorDeducoesSpecified = (notaServico.ValorDeducoes > 0);
            valores.ValorCsll = new decimal(0.0);
            valores.ValorCsllSpecified = false;

            return valores;
        }

    }
}
