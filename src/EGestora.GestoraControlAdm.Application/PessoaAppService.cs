using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application
{
    public class PessoaAppService : ApplicationService, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaService pessoaService, IUnitOfWork uow)
            :base (uow)
        {
            _pessoaService = pessoaService;
        }

        public PessoaViewModel Add(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);

            BeginTransaction();

            AddAnexoList(pessoa, pessoaViewModel.AnexoListFromPost);
            AddCnaeList(pessoa.PessoaJuridica, pessoaViewModel.SelectedCnaeList);

            var pessoaReturn = _pessoaService.Add(pessoa);
            pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoaReturn);
                      
            Commit();

            return pessoaViewModel;
        }

        public PessoaEnderecoViewModel Add(PessoaEnderecoViewModel pessoaEnderecoViewModel)
        {
            var pessoa = Mapper.Map<PessoaEnderecoViewModel, Pessoa>(pessoaEnderecoViewModel);
            var pf = Mapper.Map<PessoaEnderecoViewModel, PessoaFisica>(pessoaEnderecoViewModel);
            var pj = Mapper.Map<PessoaEnderecoViewModel, PessoaJuridica>(pessoaEnderecoViewModel);
            var endereco = Mapper.Map<PessoaEnderecoViewModel, Endereco>(pessoaEnderecoViewModel);
            var contato = Mapper.Map<PessoaEnderecoViewModel, Contato>(pessoaEnderecoViewModel);
            var foto = pessoaEnderecoViewModel.Foto;
            var selectedCnaeList = pessoaEnderecoViewModel.SelectedCnaeList;

            if (pessoaEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            pessoa.PessoaFisica = pf;
            pessoa.PessoaJuridica = pj;
            pessoa.EnderecoList.Add(endereco);
            pessoa.ContatoList.Add(contato);
            AddAnexoList(pessoa, pessoaEnderecoViewModel.Anexos);
            AddCnaeList(pessoa.PessoaJuridica, selectedCnaeList);

            var pessoaReturn = _pessoaService.Add(pessoa);
            pessoaEnderecoViewModel = Mapper.Map<Pessoa, PessoaEnderecoViewModel>(pessoaReturn);

            if (!pessoaEnderecoViewModel.ValidationResult.IsValid)
            {
                return pessoaEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, pessoaEnderecoViewModel.PessoaId, FilePathConstants.PESSOAS_IMAGE_PATH))
            {
                pessoaEnderecoViewModel.ValidationResult.Message = "Pessoa salva sem foto";
            }

            Commit();
            return pessoaEnderecoViewModel;
        }

        public PessoaViewModel GetById(Guid id)
        {
            return Mapper.Map<Pessoa, PessoaViewModel>(_pessoaService.GetById(id));
        }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaViewModel>>(_pessoaService.GetAll());
        }

        public PessoaViewModel Update(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Mapper.Map<PessoaViewModel, Pessoa>(pessoaViewModel);

            BeginTransaction();
            var pessoaResult = _pessoaService.Update(pessoa);
            pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoaResult);
            Commit();
            return pessoaViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _pessoaService.Remove(id);
            Commit();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();

            var enderecoReturn = _pessoaService.AddEndereco(endereco);
            enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(enderecoReturn);

            if (!enderecoViewModel.ValidationResult.IsValid)
            {
                return enderecoViewModel;
            }
            
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _pessoaService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_pessoaService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _pessoaService.RemoveEndereco(id);
            Commit();
        }

        public ContatoViewModel AddContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _pessoaService.AddContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _pessoaService.UpdateContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel GetContatoById(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_pessoaService.GetContatoById(id));
        }

        public void RemoveContato(Guid id)
        {
            BeginTransaction();
            _pessoaService.RemoveContato(id);
            Commit();
        }

        public IEnumerable<TipoContatoViewModel> GetAllTipoContatos()
        {
            return Mapper.Map<IEnumerable<TipoContato>, IEnumerable<TipoContatoViewModel>>(_pessoaService.GetAllTipoContatos());
        }

        public void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            BeginTransaction();

            var pessoa = _pessoaService.GetById(PessoaId);
            pessoa.AnexoList.Add(AnexoUtil.GetEntityFromHttpPostedFileBase(Arquivo));
            _pessoaService.Update(pessoa);

            Commit();
        }

        public AnexoViewModel GetAnexoById(Guid id)
        {
            return Mapper.Map<Anexo, AnexoViewModel>(_pessoaService.GetAnexoById(id));
        }

        public void RemoveAnexo(Guid id)
        {
            BeginTransaction();
            _pessoaService.RemoveAnexo(id);
            Commit();
        }

        public IEnumerable<CnaeViewModel> GetAllCnae()
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_pessoaService.GetAllCnae());
        }

        public CnaeViewModel GetCnaeById(Guid id)
        {
            return Mapper.Map<Cnae, CnaeViewModel>(_pessoaService.GetCnaeById(id));
        }

        public bool AddCnae(Guid id, Guid pessoaId)
        {
            BeginTransaction();
            var retorno = _pessoaService.AddCnae(id, pessoaId);
            Commit();
            return retorno;
        }

        public void RemoveCnae(Guid cnaeId, Guid pessoaId)
        {
            BeginTransaction();
            _pessoaService.RemoveCnae(cnaeId, pessoaId);
            Commit();
        }

        public IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id)
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_pessoaService.GetAllCnaeOutPessoa(id));
        }

        public IEnumerable<RegimeImpostoViewModel> GetAllRegimeImpostos()
        {
            return Mapper.Map<IEnumerable<RegimeImposto>, IEnumerable<RegimeImpostoViewModel>>(_pessoaService.GetAllRegimeImpostos());
        }

        public PessoaFisicaViewModel UpdatePessoaFisica(PessoaFisicaViewModel pessoaFisicaViewModel)
        {
            var pessoaFisica = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(pessoaFisicaViewModel);

            BeginTransaction();
            var pessoaFisicaReturn = _pessoaService.UpdatePessoaFisica(pessoaFisica);
            pessoaFisicaViewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pessoaFisicaReturn);
            Commit();
            return pessoaFisicaViewModel;
        }

        public PessoaJuridicaViewModel UpdatePessoaJuridica(PessoaJuridicaViewModel pessoaJuridicaViewModel)
        {
            var pessoaJuridica = Mapper.Map<PessoaJuridicaViewModel, PessoaJuridica>(pessoaJuridicaViewModel);

            BeginTransaction();
            var pessoaJuridicaReturn = _pessoaService.UpdatePessoaJuridica(pessoaJuridica);
            pessoaJuridicaViewModel = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(pessoaJuridicaReturn);
            Commit();
            return pessoaJuridicaViewModel;
        }

        public IEnumerable<ProfissaoViewModel> GetAllProfissoes()
        {
            return Mapper.Map<IEnumerable<Profissao>, IEnumerable<ProfissaoViewModel>>(_pessoaService.GetAllProfissoes());
        }

        public FuncionarioViewModel AddFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            BeginTransaction();
            var funcionarioReturn = _pessoaService.AddFuncionario(funcionario);
            funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionarioReturn);
            Commit();
            return funcionarioViewModel;
        }

        public FuncionarioViewModel UpdateFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionarioViewModel);

            BeginTransaction();
            var funcionarioReturn = _pessoaService.UpdateFuncionario(funcionario);
            funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionarioReturn);
            Commit();
            return funcionarioViewModel;
        }

        public FuncionarioViewModel GetFuncionarioById(Guid id)
        {
            return Mapper.Map<Funcionario, FuncionarioViewModel>(_pessoaService.GetFuncionarioById(id));
        }

        public void RemoveFuncionario(Guid id)
        {
            BeginTransaction();
            _pessoaService.RemoveFuncionario(id);
            Commit();
        }

        public ProprietarioViewModel AddProprietario(ProprietarioViewModel proprietarioViewModel)
        {
            var proprietario = Mapper.Map<ProprietarioViewModel, Proprietario>(proprietarioViewModel);

            BeginTransaction();
            var proprietarioReturn = _pessoaService.AddProprietario(proprietario);
            proprietarioViewModel = Mapper.Map<Proprietario, ProprietarioViewModel>(proprietarioReturn);
            Commit();
            return proprietarioViewModel;
        }

        public ProprietarioViewModel UpdateProprietario(ProprietarioViewModel proprietarioViewModel)
        {
            var proprietario = Mapper.Map<ProprietarioViewModel, Proprietario>(proprietarioViewModel);

            BeginTransaction();
            var proprietarioReturn = _pessoaService.UpdateProprietario(proprietario);
            proprietarioViewModel = Mapper.Map<Proprietario, ProprietarioViewModel>(proprietarioReturn);
            Commit();
            return proprietarioViewModel;
        }

        public ProprietarioViewModel GetProprietarioById(Guid id)
        {
            return Mapper.Map<Proprietario, ProprietarioViewModel>(_pessoaService.GetProprietarioById(id));
        }

        public void RemoveProprietario(Guid id)
        {
            BeginTransaction();
            _pessoaService.RemoveProprietario(id);
            Commit();
        }

        public IEnumerable<PessoaFisicaViewModel> GetAllPessoaFisica()
        {
            return Mapper.Map<IEnumerable<PessoaFisica>, IEnumerable<PessoaFisicaViewModel>>(_pessoaService.GetAllPessoaFisica());
        }

        public IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridica()
        {
            return Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(_pessoaService.GetAllPessoaJuridica());
        }

        public IEnumerable<CargoViewModel> GetAllCargo()
        {
            return Mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoViewModel>>(_pessoaService.GetAllCargo());

        }

        public void Dispose()
        {
            _pessoaService.Dispose();
            GC.SuppressFinalize(this);
        }

        private void AddCnaeList(PessoaJuridica pessoaJuridica, IEnumerable<Guid> selectedCnaeList)
        {
            if (pessoaJuridica != null)
            {
                foreach (var CnaeId in selectedCnaeList)
                {
                    var cnae = _pessoaService.GetCnaeById(CnaeId);
                    pessoaJuridica.CnaeList.Add(cnae);
                }
            }
        }

        private static void AddAnexoList(Pessoa pessoa, IEnumerable<HttpPostedFileBase> anexoList)
        {
            foreach (var anexo in anexoList)
            {
                var anexoEntity = AnexoUtil.GetEntityFromHttpPostedFileBase(anexo);
                if (anexoEntity != null)
                {
                    pessoa.AnexoList.Add(anexoEntity);
                }
            }
        }
    }
}
