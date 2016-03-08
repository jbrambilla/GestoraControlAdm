using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Simpliss;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;

namespace EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao
{
    public class EnderecoTomadorNfse : IEnderecoTomadorNfse
    {
        public tcEndereco GetEnderecoTomador(NotaServico notaServico)
        {
            Endereco endereco = notaServico.Cliente.EnderecoList.FirstOrDefault();

            var enderecoTomador = new tcEndereco();
            enderecoTomador.Endereco = endereco.Logradouro;
            enderecoTomador.Numero = endereco.Numero;
            enderecoTomador.Bairro = endereco.Bairro;
            enderecoTomador.Uf = endereco.Estado;
            enderecoTomador.Cep = Convert.ToInt32(endereco.Cep);
            enderecoTomador.CepSpecified = true;
            enderecoTomador.CodigoMunicipio = 3541406;//Convert.ToInt32(endereco.Cidade.CidadeCodigo.Replace("-", ""));
            enderecoTomador.CodigoMunicipioSpecified = true; //(cidadeCodigo > 0);

            return enderecoTomador;
        }

    }
}
