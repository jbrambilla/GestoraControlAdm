using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.CodigoSegurancas;

namespace EGestora.GestoraControlAdm.Domain.Validations.CodigoSegurancas
{
    public class CodigoSegurancaEstaAptoParaCadastroValidation : Validator<CodigoSeguranca>
    {
        public CodigoSegurancaEstaAptoParaCadastroValidation(ICodigoSegurancaRepository codigoSegurancaRepository)
        {
            var codigo = new CodigoSegurancaDeveGerarCodigoCorretoSpecification(codigoSegurancaRepository);

            base.Add("codigo", new Rule<CodigoSeguranca>(codigo, "O Código gerado não confere."));
        }
    }
}
