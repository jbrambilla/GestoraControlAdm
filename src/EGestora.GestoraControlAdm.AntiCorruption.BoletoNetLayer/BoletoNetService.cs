using BoletoNet;
using EGestora.GestoraControlAdm.Domain.Interfaces.BoletoNet;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;

namespace EGestora.GestoraControlAdm.AntiCorruption.BoletoNetLayer
{
    public class BoletoNetService : IBoletoNetService
    {
        private readonly IEmpresaRepository _empresarepository;

        public BoletoNetService(IEmpresaRepository empresarepository)
        {
            _empresarepository = empresarepository;
        }

        public string GetHtml(Domain.Entities.Boleto boleto)
        {
            var boletoBancario = PreencherDadosBoleto(boleto);

            return boletoBancario.MontaHtmlEmbedded();
        }

        public byte[] GetBytes(Domain.Entities.Boleto boleto)
        {
            var boletoBancario = PreencherDadosBoleto(boleto);

            return boletoBancario.MontaBytesPDF();
        }

        private static BoletoBancario PreencherDadosBoleto(Domain.Entities.Boleto boleto)
        {
            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 104;

            DateTime vencimento = new DateTime(2008, 12, 20);

            Cedente c = new Cedente("000.000.000-00", "Boleto.net ILTDA", "1234", "12345678", "9");

            c.Codigo = "112233";


            BoletoNet.Boleto b = new BoletoNet.Boleto(vencimento, 20.00m, "2", "0123456789", c);

            b.Sacado = new Sacado("000.000.000-00", "Nome do seu Cliente ");
            b.Sacado.Endereco.End = "Endereço do seu Cliente ";
            b.Sacado.Endereco.Bairro = "Bairro";
            b.Sacado.Endereco.Cidade = "Cidade";
            b.Sacado.Endereco.CEP = "00000000";
            b.Sacado.Endereco.UF = "UF";

            //Adiciona as instruções ao boleto
            #region Instruções
            Instrucao_Caixa item;
            //ImportanciaporDiaDesconto
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.Multa, Convert.ToDecimal(0.40));
            b.Instrucoes.Add(item);
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.JurosdeMora, Convert.ToDecimal(0.01));
            b.Instrucoes.Add(item);
            item = new Instrucao_Caixa((int)EnumInstrucoes_Caixa.NaoReceberAposNDias, 90);
            b.Instrucoes.Add(item);
            #endregion Instruções

            EspecieDocumento_Caixa espDocCaixa = new EspecieDocumento_Caixa();
            b.EspecieDocumento = new EspecieDocumento_Caixa(espDocCaixa.getCodigoEspecieByEnum(EnumEspecieDocumento_Caixa.DuplicataMercantil));
            b.NumeroDocumento = "00001";
            b.DataProcessamento = DateTime.Now;
            b.DataDocumento = DateTime.Now;

            boletoBancario.Boleto = b;
            boletoBancario.Boleto.Valida();

            return boletoBancario;
        }

    }
}
