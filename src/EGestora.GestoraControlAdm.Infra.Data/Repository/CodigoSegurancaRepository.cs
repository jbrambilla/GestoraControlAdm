using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class CodigoSegurancaRepository : RepositoryBase<CodigoSeguranca>, ICodigoSegurancaRepository
    {
        public CodigoSegurancaRepository(EGestoraContext context)
            :base (context)
        {
        }

        public void GerarCodigo(CodigoSeguranca codigoSeguranca)
        {
            var diffDataAtual = codigoSeguranca.DataAtual.Subtract(DateTime.Parse("29/05/2000")).Days.ToString().PadLeft(4,'0');
            var diffDataTrava = codigoSeguranca.DataTrava.Subtract(DateTime.Parse("29/05/2000")).Days.ToString().PadLeft(4, '0');
            var cnpj = codigoSeguranca.Cliente.PessoaJuridica.Cnpj.Replace(".", "").Replace("-", "").Replace("/", "").PadLeft(14, '0');

            var primeiroTotal = 0;
            var segundoTotal = 0;
            var cnpjDatas = cnpj + diffDataAtual;
            var constante1 = "987654329876543298";
            var constante2 = "9876543298765432987654";

            for (int i = 0; i < constante1.Length; i++)
            {
                primeiroTotal += cnpjDatas[i] * constante1[i];
            }

            cnpjDatas += diffDataTrava;

            for (int i = 0; i < constante2.Length; i++)
            {
                segundoTotal += cnpjDatas[i] * constante2[i];
            }

            codigoSeguranca.Codigo = primeiroTotal.ToString().PadLeft(4, '0') + diffDataTrava + segundoTotal.ToString().PadLeft(4, '0');
        }
    }
}
