using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ;

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
            var contato = new PessoaDeveTerUmContatoSpecification();
            var nome = new PessoaFisicaDeveTerNomeObrigatorioSpecification();
            var razaoSocial = new PessoaJuridicaDeveTerRazaoSocialObrigatorioSpecification();
            var nomeFantasia = new PessoaJuridicaDeveTerNomeFantasiaObrigatorioSpecification();

            base.Add("cnpj", new Rule<Pessoa>(cnpj, "O CNPJ informado é inválido."));
            base.Add("cpf", new Rule<Pessoa>(cpf, "O CPF informado é inválido."));
            base.Add("pfOuPj", new Rule<Pessoa>(pfOuPj, "A Entidade precisa ser Física ou Jurídica."));
            base.Add("endereco", new Rule<Pessoa>(endereco, "É necessário possuir um Endereço para o cadastro."));
            base.Add("contato", new Rule<Pessoa>(contato, "É necessário possuir um Contato para o cadastro."));
            base.Add("nome", new Rule<Pessoa>(nome, "O campo Nome é obrigatório."));
            base.Add("razaoSocial", new Rule<Pessoa>(razaoSocial, "O campo Razão Social é obrigatório."));
            base.Add("nomeFantasia", new Rule<Pessoa>(nomeFantasia, "O campo Nome Fantasia é obrigatório."));
        }
    }
}
