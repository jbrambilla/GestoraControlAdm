using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(EGestoraContext context)
            : base(context)
        {

        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return Search(f => f.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Fornecedor GetByCpf(string cpf)
        {
            return Search(f => f.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public override IEnumerable<Fornecedor> GetAll()
        {
            return Db.Fornecedores.Where(c => c.Ativo).ToList();
        }

        public override void Remove(Guid id)
        {
            var fornecedor = GetById(id);
            fornecedor.Ativo = false;
            Update(fornecedor);
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridica()
        {
            var pjList = new List<PessoaJuridica>();
            var fornecedoresPj = Search(c => c.PessoaJuridica != null && c.Ativo).ToList();
            foreach (var fornecedor in fornecedoresPj)
            {
                pjList.Add(fornecedor.PessoaJuridica);
            }
            return pjList;
        }

        public IEnumerable<PessoaFisica> GetAllPessoaFisica()
        {
            var pfList = new List<PessoaFisica>();
            var fornecedoresPf = Search(c => c.PessoaFisica != null && c.Ativo).ToList();
            foreach (var fornecedor in fornecedoresPf)
            {
                pfList.Add(fornecedor.PessoaFisica);
            }
            return pfList;
        }
    }
}
