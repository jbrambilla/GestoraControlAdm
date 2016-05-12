using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PF;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ;

namespace EGestora.GestoraControlAdm.Domain.Validations.Pessoas
{
    public class PessoaEstaAptaParaCadastroValidation : Validator<Pessoa>
    {
        public PessoaEstaAptaParaCadastroValidation(IPessoaRepository pessoaRepository)
        {
            var cnpjUnico = new PessoaJuridicaDevePossuirCnpjUnicoSpecification(pessoaRepository);
            var cpfUnico = new PessoaFisicaDevePossuirCpfUnicoSpecification(pessoaRepository);

            base.Add("cnpjUnico", new Rule<Pessoa>(cnpjUnico, "Este CNPJ já está cadastrado."));
            base.Add("cpfUnico", new Rule<Pessoa>(cpfUnico, "Este CPF já está cadastrado."));
        }
    }
}
