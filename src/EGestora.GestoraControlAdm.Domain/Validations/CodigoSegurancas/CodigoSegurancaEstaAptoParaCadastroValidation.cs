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
            var clientesDevedores = new CodigoSegurancaNaoDeveGerarCodigoParaClientesDevedoresSpecification();

            base.Add("codigo", new Rule<CodigoSeguranca>(codigo, "O Código gerado não confere."));
            base.Add("clientesDevedores", new Rule<CodigoSeguranca>(clientesDevedores, "Não é possível gerar o código para Clientes com débito pendente."));
        }
    }
}
