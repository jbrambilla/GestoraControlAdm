using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Add(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel GetById(Guid id);
        ClienteViewModel GetByCnpj(string cnpj);
        ClienteViewModel GetByCpf(string cpf);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel Update(ClienteViewModel clienteViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        IEnumerable<CnaeViewModel> GetAllCnae();
        CnaeViewModel GetCnaeById(Guid id);
        void AddCnae(Guid id, Guid pessoaId);
        void RemoveCnae(Guid cnaeId, Guid pessoaId);
        IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id);

        IEnumerable<ServicoViewModel> GetAllServicos();
        IEnumerable<ServicoViewModel> GetAllServicosOutPessoa(Guid id);
        ClienteServicoViewModel AddServico(ClienteServicoViewModel clienteServicoViewModel);

        ClienteServicoViewModel GetClienteServicoById(Guid id);
        void RemoveClienteServico(Guid id);

        IEnumerable<RevendaViewModel> GetAllRevendas();
        IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridicaDeRevendas();
        RevendaViewModel GetRevendaById(Guid id);
        void RemoveRevenda(Guid pessoaId);
        void AddRevenda(Guid pessoaId, Guid revendaId);

        IEnumerable<RegimeApuracaoViewModel> GetAllRegimeApuracao();
    }
}
