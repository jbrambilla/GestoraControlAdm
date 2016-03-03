using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.NotaServicos;

namespace EGestora.GestoraControlAdm.Domain.Validations.NotaServicos
{
    public class NotaServicoEstaConsistenteValidation : Validator<NotaServico>
    {
        public NotaServicoEstaConsistenteValidation()
        {
            var calculoCorreto = new NotaServicoDeveTerCalculoDeValoresCorretoSpecification();

            base.Add("calculoCorreto", new Rule<NotaServico>(calculoCorreto, "O Cálculo dos valores está incorreto."));
        }
    }
}
