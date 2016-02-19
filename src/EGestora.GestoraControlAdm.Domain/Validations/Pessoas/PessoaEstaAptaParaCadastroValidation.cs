using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Specifications.Pessoas;

namespace EGestora.GestoraControlAdm.Domain.Validations.Pessoas
{
    public class PessoaEstaAptaParaCadastroValidation<TEntity> : Validator<Pessoa> where TEntity : class
    {
        public PessoaEstaAptaParaCadastroValidation(IPessoaRepository<TEntity> pessoaRepository)
        {
            var cnpjUnico = new PessoaJuridicaDevePossuirCnpjUnicoSpecification<TEntity>(pessoaRepository);
            var cpfUnico = new PessoaFisicaDevePossuirCpfUnicoSpecification<TEntity>(pessoaRepository);

            base.Add("cnpjUnico", new Rule<Pessoa>(cnpjUnico, "Este CNPJ já está cadastrado."));
            base.Add("cpfUnico", new Rule<Pessoa>(cpfUnico, "Este CPF já está cadastrado."));
        }
    }
}
