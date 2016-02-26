using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(EGestoraContext context)
            : base(context)
        {

        }

        public Funcionario GetByCnpj(string cnpj)
        {
            return Search(f => f.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Funcionario GetByCpf(string cpf)
        {
            return Search(f => f.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridica()
        {
            var pjList = new List<PessoaJuridica>();
            var funcionariosPj = Search(c => c.PessoaJuridica != null && c.Ativo).ToList();
            foreach (var funcionario in funcionariosPj)
            {
                pjList.Add(funcionario.PessoaJuridica);
            }
            return pjList;
        }

        public IEnumerable<PessoaFisica> GetAllPessoaFisica()
        {
            var pfList = new List<PessoaFisica>();
            var funcionariosPf = Search(c => c.PessoaFisica != null && c.Ativo).ToList();
            foreach (var funcionario in funcionariosPf)
            {
                pfList.Add(funcionario.PessoaFisica);
            }
            return pfList;
        }
    }
}
