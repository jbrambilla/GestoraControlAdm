using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas;

namespace EGestora.GestoraControlAdm.Domain.Validations.CodigoSegurancas
{
    public class CodigoSegurancaEstaConsistenteValidation : Validator<CodigoSeguranca>
    {
        public CodigoSegurancaEstaConsistenteValidation()
        {
            var dataTrava = new CodigoSegurancaDataTravaDeveSerMaiorQueDataDeHojeSpecification();

            base.Add("dataTrava", new Rule<CodigoSeguranca>(dataTrava, "A Data da Trava deve ser maior que a data de hoje."));
        }
    }
}
