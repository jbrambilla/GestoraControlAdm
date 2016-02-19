using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;

namespace EGestora.GestoraControlAdm.Domain.Validations.Pessoas
{
    public class PessoaEstaConsistenteValidation : Validator<Pessoa>
    {
        public PessoaEstaConsistenteValidation()
        {
            var cnpj = new PessoaJuridicaDeveTerCnpjValidoSpecification();
            var cpf = new PessoaFisicaDeveTerCpfValidoSpecification();
            var pfOuPj = new PessoaDeveSerJuridicaOuFisicaSpecification();
            var endereco = new PessoaDeveTerUmEnderecoSpecification();

            base.Add("cnpj", new Rule<Pessoa>(cnpj, "O CNPJ informado é inválido."));
            base.Add("cpf", new Rule<Pessoa>(cpf, "O CPF informado é inválido."));
            base.Add("pfOuPj", new Rule<Pessoa>(pfOuPj, "A Entidade precisa ser Física ou Jurídica."));
            base.Add("endereco", new Rule<Pessoa>(endereco, "É necessário possuir um Endereço para o cadastro."));
        }
    }
}
