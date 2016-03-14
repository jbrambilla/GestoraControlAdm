using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.LoteFaturamentos;

namespace EGestora.GestoraControlAdm.Domain.Validations.LoteFaturamentos
{
    public class LoteFaturamentoEstaConsistenteValidation : Validator<LoteFaturamento>
    {
        public LoteFaturamentoEstaConsistenteValidation()
        {
            var cliente = new LoteDeveTerClienteSpecification();

            base.Add("cliente", new Rule<LoteFaturamento>(cliente, "Para salvar o Lote, é necessário selecionar pelo menos um cliente."));
        }
    }
}
