using DomainValidation.Validation;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService
{
    public class NotaServicoNfseWebService : INotaServicoNfseWebService
    {
        private readonly INovaNfse _novaNfse;
        private readonly ICredencialNfse _credencialNfse;
        private readonly IDadosTomadorNfse _dadosTomadorNfse;
        private readonly IIdentificacaoPrestadorNfse _identificacaoPrestadorNfse;
        private readonly IEnderecoTomadorNfse _enderecoTomadorNfse;
        private readonly IContatoTomadorNfse _contatoTomadorNfse;
        private readonly IDadosServicoNfse _dadosServicoNfse;
        private readonly IItensServicoNfse _itensServicoNfse;
        private readonly IValoresServicoNfse _valoresServicoNfse;

        public NotaServicoNfseWebService(
            INovaNfse novaNfse,
            ICredencialNfse credencialNfse,
            IDadosTomadorNfse dadosTomadorNfse,
            IIdentificacaoPrestadorNfse identificacaoPrestadorNfse,
            IEnderecoTomadorNfse enderecoTomadorNfse,
            IContatoTomadorNfse contatoTomadorNfse,
            IDadosServicoNfse dadosServicoNfse,
            IItensServicoNfse itensServicoNfse,
            IValoresServicoNfse valoresServicoNfse)
        {
            _novaNfse = novaNfse;
            _credencialNfse = credencialNfse;
            _dadosTomadorNfse = dadosTomadorNfse;
            _enderecoTomadorNfse = enderecoTomadorNfse;
            _identificacaoPrestadorNfse = identificacaoPrestadorNfse;
            _contatoTomadorNfse = contatoTomadorNfse;
            _dadosServicoNfse = dadosServicoNfse;
            _itensServicoNfse = itensServicoNfse;
            _valoresServicoNfse = valoresServicoNfse;
        }



        public NotaServico Gerar(NotaServico notaServico)
        {
            var GerarNovaNfse = new GerarNovaNfseEnvio();
            var ws = new NfseService();
            ws.Url = notaServico.Empresa.WebServiceHomologacao;
            var Credencial = _credencialNfse.GetCredencial(notaServico);

            GerarNovaNfse.Prestador = _identificacaoPrestadorNfse.GetIdentificacaoPrestador(notaServico);
            GerarNovaNfse.InformacaoNfse = _novaNfse.GetNovaNfse(notaServico);
            GerarNovaNfse.InformacaoNfse.Tomador = _dadosTomadorNfse.GetDadosTomador(notaServico);
            GerarNovaNfse.InformacaoNfse.Tomador.Endereco = _enderecoTomadorNfse.GetEnderecoTomador(notaServico);
            GerarNovaNfse.InformacaoNfse.Tomador.Contato = _contatoTomadorNfse.GetContatoTomador(notaServico);
            GerarNovaNfse.InformacaoNfse.Servico = _dadosServicoNfse.GetDadosServico(notaServico);
            GerarNovaNfse.InformacaoNfse.Servico.ItensServico = _itensServicoNfse.GetItensServico(notaServico);
            GerarNovaNfse.InformacaoNfse.Servico.Valores = _valoresServicoNfse.GetValoresServico(notaServico);

            try
            {
                var RespostaNfse = ws.GerarNfse(GerarNovaNfse, Credencial);
                
                if (RespostaNfse is GerarNovaNfseResposta)
                {
                    if (RespostaNfse.Item is GerarNovaNfseRespostaListaMensagemRetorno)
                    {
                        GerarNovaNfseRespostaListaMensagemRetorno retorno = (GerarNovaNfseRespostaListaMensagemRetorno)RespostaNfse.Item;
                        foreach (tcMensagemRetorno mensagem in retorno.MensagemRetorno)
                        {
                            notaServico.ValidationResult.Add(
                                new ValidationError(
                                    "Código: " + mensagem.Codigo + ". " +
                                    "Mensagem: " + mensagem.Mensagem + ". " +
                                    "Correção: " + mensagem.Correcao + "."
                                )
                            );
                        }
                    }
                    else if (RespostaNfse.Item is tcRespostaIdentNovaNfse)
                    {
                        var item = (tcRespostaIdentNovaNfse)RespostaNfse.Item;
                        notaServico.Numero = item.IdentificacaoNfse.Numero;
                        notaServico.Serie = item.IdentificacaoNfse.Serie;
                        notaServico.CodigoVerificacao = item.IdentificacaoNfse.CodigoVerificacao;
                        notaServico.ValidationResult.Message = "Nota finalizada com sucesso!";
                        notaServico.NotaFinalizada = true;
                    }
                    else
                    {
                        notaServico.ValidationResult.Add(new ValidationError("resp.Item is NFSeSimpliss.GerarNovaNfseRespostaListaMensagemRetorno = false <E> resp.Item is NFSeSimpliss.tcRespostaIdentNovaNfse = false"));
                    }
                }
                else
                {
                    notaServico.ValidationResult.Add(new ValidationError("resp is NFSeSimpliss.GerarNovaNfseResposta = false"));
                }

            }
            catch (Exception ex)
            {
                notaServico.ValidationResult.Add(new ValidationError("Falha ao transmitir, entre em contato com o suporte:\n" + ex.Message));
            }

            return notaServico;
        }


        public NotaServico Cancelar(NotaServico notaServico)
        {
            throw new NotImplementedException();
        }

        public NotaServico ConsultarPorRps(string rps)

        {
            throw new NotImplementedException();
        }
    }
}
