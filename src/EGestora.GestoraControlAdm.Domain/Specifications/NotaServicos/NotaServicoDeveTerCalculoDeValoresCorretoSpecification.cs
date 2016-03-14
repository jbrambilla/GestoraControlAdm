using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Specifications.NotaServicos
{
    public class NotaServicoDeveTerCalculoDeValoresCorretoSpecification : ISpecification<NotaServico>
    {
        public bool IsSatisfiedBy(NotaServico notaServico)
        {
            var valorLiquidoAtual = notaServico.ValorLiquido;
            var valorLiquidoEsperado = obterValorLiquidoEsperado(notaServico);

            return valorLiquidoAtual == valorLiquidoEsperado;
        }

        private decimal obterValorLiquidoEsperado(NotaServico notaServico)
        {
            var cliente = notaServico.Cliente;
            var empresa = notaServico.Empresa;

            var total = cliente.ValorTotalServicos;
            var aliquota = empresa.Aliquota;
            var baseCalculo = total;
            var valorISS = baseCalculo * (aliquota / 100);
            return total - valorISS;
        }
    }
}
