using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Add(Cliente cliente);
        Cliente GetById(Guid id);
        Cliente GetByCnpj(string cnpj);
        Cliente GetByCpf(string cpf);
        IEnumerable<Cliente> GetAll();
        Cliente Update(Cliente cliente);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        Contato AddContato(Contato contato);
        Contato UpdateContato(Contato contato);
        Contato GetContatoById(Guid id);
        void RemoveContato(Guid id);

        PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica);
        PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica);

        IEnumerable<Cnae> GetAllCnae();
        Cnae GetCnaeById(Guid id);
        void RemoveCnae(Guid id, Guid pessoaId);
        void AddCnae(Guid id, Guid pessoaId);
        IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id);

        Servico GetServicoById(Guid id);
        IEnumerable<Servico> GetAllServicos();
        IEnumerable<Servico> GetAllServicosOutPessoa(Guid id);
        ClienteServico AddServico(ClienteServico clienteServico);

        ClienteServico GetClienteServicoById(Guid id);
        void RemoveClienteServico(Guid id);

        IEnumerable<Revenda> GetAllRevendas();
        IEnumerable<PessoaJuridica> GetAllPessoaJuridicaDeRevendas();
        Revenda GetRevendaById(Guid id);
        void RemoveRevenda(Guid pessoaId);
        void AddRevenda(Guid pessoaId, Guid revendaId);

        IEnumerable<RegimeApuracao> GetAllRegimeApuracao();

        Anexo GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);

        Debito GetDebitoById(Guid id);
        void BaixarDebito(Guid id, DateTime DataBaixa);
        Debito AdicionarDebito(Debito debito);
    }
}
