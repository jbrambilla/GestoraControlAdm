using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(EGestoraContext context)
            : base (context)
        {
        }

        public override void Remove(Guid id)
        {
            var empresa = GetById(id);
            empresa.Ativo = false;
            Update(empresa);
        }

        public Empresa GetByCnpj(string cnpj)
        {
            return Search(c => c.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Empresa GetByCpf(string cpf)
        {
            return Search(c => c.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridica()
        {
            var pjList = new List<PessoaJuridica>();
            var empresasPj = Search(c => c.PessoaJuridica != null && c.Ativo).ToList();
            foreach (var empresa in empresasPj)
            {
                pjList.Add(empresa.PessoaJuridica);
            }
            return pjList;
        }

        public IEnumerable<PessoaFisica> GetAllPessoaFisica()
        {
            var pfList = new List<PessoaFisica>();
            var empresasPf = Search(c => c.PessoaFisica != null && c.Ativo).ToList();
            foreach (var empresa in empresasPf)
            {
                pfList.Add(empresa.PessoaFisica);
            }
            return pfList;
        }

        public Empresa GetEmpresaAtiva()
        {
            return Db.Empresas.FirstOrDefault(e => e.Ativo);
        }
    }
}
