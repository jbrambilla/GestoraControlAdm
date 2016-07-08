using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;
using System.Linq;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(EGestoraContext context)
            : base(context)
        {

        }

        public Cliente GetByCnpj(string cnpj)
        {
            return Search(c => c.Pessoa.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Cliente GetByCpf(string cpf)
        {
            return Search(c => c.Pessoa.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public override IEnumerable<Cliente> GetAll()
        {
            return Db.Clientes.Where(c => c.Pessoa.Ativo).ToList();
        }

        public override void Remove(Guid id)
        {
            var cliente = GetById(id);
            cliente.Pessoa.Ativo = false;
            Update(cliente);
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridica()
        {
            var pjList = new List<PessoaJuridica>();
            var clientesPj = Search(c => c.Pessoa.PessoaJuridica != null && c.Pessoa.Ativo).ToList();
            foreach (var cliente in clientesPj)
            {
                pjList.Add(cliente.Pessoa.PessoaJuridica);
            }
            return pjList;
        }

        public IEnumerable<PessoaFisica> GetAllPessoaFisica()
        {
            var pfList = new List<PessoaFisica>();
            var clientesPf = Search(c => c.Pessoa.PessoaFisica != null && c.Pessoa.Ativo).ToList();
            foreach (var cliente in clientesPf)
            {
                pfList.Add(cliente.Pessoa.PessoaFisica);
            }
            return pfList;
        }

        public IEnumerable<Cliente> GetAllSemNota()
        {
            return Db.Clientes.Where(c => !c.ComNota && c.Pessoa.Ativo).ToList();
        }

        public IEnumerable<Cliente> GetAllComNota()
        {
            return Db.Clientes.Where(c => c.ComNota && c.Pessoa.Ativo).ToList();
        }
    }
}
