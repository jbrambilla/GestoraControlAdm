using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Debitos;

namespace EGestora.GestoraControlAdm.Domain.Validations.Debitos
{
    public class DebitoEstaConsistenteValidation : Validator<Debito>
    {
        public DebitoEstaConsistenteValidation()
        {
            var vencimento = new DebitoVencimentoDeveSerMaiorQueDataAtualSpecification();

            base.Add("vencimento", new Rule<Debito>(vencimento, "A data de vencimento deve ser maior que a data atual."));
        }
    }
}
