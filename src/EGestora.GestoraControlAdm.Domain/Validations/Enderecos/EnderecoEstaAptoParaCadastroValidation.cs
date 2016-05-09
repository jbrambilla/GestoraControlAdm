using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Enderecos;

namespace EGestora.GestoraControlAdm.Domain.Validations.Enderecos
{
    public class EnderecoEstaAptoParaCadastroValidation : Validator<Endereco>
    {
        public EnderecoEstaAptoParaCadastroValidation(IEnderecoRepository enderecoRepository)
        {
            var enderecoCobrancaUnico = new PessoaDevePossuirUmEnderecoCobrancaSpecification(enderecoRepository);
            var enderecoEntregaUnico = new PessoaDevePossuirUmEnderecoEntregaSpecification(enderecoRepository);
            var enderecoPrincipalUnico = new PessoaDevePossuirUmEnderecoPrincipalSpecification(enderecoRepository);

            base.Add("enderecoCobrancaUnico", new Rule<Endereco>(enderecoCobrancaUnico, "Não é possível cadastrar mais de um endereço de cobrança para uma pessoa."));
            base.Add("enderecoEntregaUnico", new Rule<Endereco>(enderecoEntregaUnico, "Não é possível cadastrar mais de um endereço de entrega para uma pessoa."));
            base.Add("enderecoPrincipalUnico", new Rule<Endereco>(enderecoPrincipalUnico, "Não é possível cadastrar mais de um endereço principal para uma pessoa."));
        }
    }
}
