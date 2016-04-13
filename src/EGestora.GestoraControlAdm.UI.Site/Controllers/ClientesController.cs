using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.UI.Site.Models;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }        

        // GET: Clientes
        public ActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.GetById(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = id.Value;
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Add(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    loadViewBags();
                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.GetById(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            loadViewBags();
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Update(clienteViewModel);
                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.GetById(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);
            return RedirectToAction("Index");
        }


        //Endereço


        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Clientes";
            return PartialView("_EnderecoList", _clienteAppService.GetById(id).EnderecoList);
        }

        [Route("adicionar-endereco")]
        public ActionResult AdicionarEndereco(Guid id)
        {
            ViewBag.PessoaId = id;
            return PartialView("_AdicionarEndereco");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AddEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _clienteAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", enderecoViewModel);
        }

        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enderecoViewModel = _clienteAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var pessoaId = _clienteAppService.GetEnderecoById(id).PessoaId;
            _clienteAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url });
        }

        //Contato
        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Clientes";
            return PartialView("_ContatoList", _clienteAppService.GetById(id).ContatoList);
        }

        [Route("adicionar-contato")]
        public ActionResult AdicionarContato(Guid id)
        {
            ViewBag.PessoaId = id;
            return PartialView("_AdicionarContato");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AddContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Clientes", new { id = contatoViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "contato" });
            }

            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            return PartialView("_AtualizarContato", _clienteAppService.GetContatoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.UpdateContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Clientes", new { id = contatoViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "contato" });
            }

            return PartialView("_AtualizarContato", contatoViewModel);
        }

        public ActionResult DeletarContato(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contatoViewModel = _clienteAppService.GetContatoById(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarContato", contatoViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarContato")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmed(Guid id)
        {
            var pessoaId = _clienteAppService.GetContatoById(id).PessoaId;
            _clienteAppService.RemoveContato(id);

            string url = Url.Action("ListarContatos", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "contato" });
        }

        //CNAE

        public ActionResult ListarCnaes(Guid id)
        {
            ViewBag.PessoaId = id;

            return PartialView("_CnaeList", _clienteAppService.GetById(id).CnaeList);
        }

        [Route("adicionar-cnae")]
        public ActionResult AdicionarCnae(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.CnaeList = new SelectList(_clienteAppService.GetAllCnaeOutPessoa(id.Value).OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            return PartialView("_AdicionarCnae");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarCnae(Guid PessoaId, Guid CnaeId)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AddCnae(CnaeId, PessoaId);

                string url = Url.Action("ListarCnaes", "Clientes", new { id = PessoaId});
                return Json(new { success = true, url = url, replaceTarget = "cnae" });
            }
            ViewBag.PessoaId = PessoaId;
            ViewBag.CnaeList = new SelectList(_clienteAppService.GetAllCnaeOutPessoa(PessoaId).OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            return PartialView("_AdicionarCnae");
        }

        public ActionResult DeletarCnae(Guid? id, Guid? pessoaId)
        {
            if (id == null || pessoaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cnaeViewModel = _clienteAppService.GetCnaeById(id.Value);
            if (cnaeViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = pessoaId;
            return PartialView("_DeletarCnae", cnaeViewModel);
        }

        [HttpPost, ActionName("DeletarCnae")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarCnaeConfirmed(Guid id, Guid pessoaId)
        {
            _clienteAppService.RemoveCnae(id, pessoaId);

            string url = Url.Action("ListarCnaes", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "cnae" });
        }

        //SERVIÇOS

        public ActionResult ListarServicos(Guid id)
        {
            ViewBag.PessoaId = id;

            return PartialView("_ServicoList", _clienteAppService.GetById(id).ClienteServicoList);
        }

        [Route("adicionar-servico")]
        public ActionResult AdicionarServico(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.ServicoList = new SelectList(_clienteAppService.GetAllServicosOutPessoa(id.Value).OrderBy(s => s.Descricao), "ServicoId", "Descricao");
            return PartialView("_AdicionarServico");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarServico(ClienteServicoViewModel clienteServicoViewModel)
        {
            var PessoaId = clienteServicoViewModel.PessoaId;

            if (ModelState.IsValid)
            {
                _clienteAppService.AddServico(clienteServicoViewModel);

                string url = Url.Action("ListarServicos", "Clientes", new { id = PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "servico" });
            }
            ViewBag.PessoaId = PessoaId;
            ViewBag.ServicoList = new SelectList(_clienteAppService.GetAllServicosOutPessoa(PessoaId).OrderBy(s => s.Descricao), "ServicoId", "Descricao");
            return PartialView("_AdicionarServico");
        }

        public ActionResult DeletarServico(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteServicoViewModel = _clienteAppService.GetClienteServicoById(id.Value);
            if (clienteServicoViewModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DeletarServico", clienteServicoViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarServico")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarServicoConfirmed(Guid id)
        {
            var pessoaId = _clienteAppService.GetClienteServicoById(id).PessoaId;
            _clienteAppService.RemoveClienteServico(id);

            string url = Url.Action("ListarServicos", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "servico" });
        }

        //REVENDA

        public ActionResult ListarRevenda(Guid id)
        {
            ViewBag.PessoaId = id;

            return PartialView("_RevendaList", _clienteAppService.GetById(id).Revenda);
        }

        [Route("adicionar-revenda")]
        public ActionResult AdicionarRevenda(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.RevendaList = new SelectList(_clienteAppService.GetAllPessoaJuridicaDeRevendas().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            return PartialView("_AdicionarRevenda");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarRevenda(Guid PessoaId, Guid RevendaId)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AddRevenda(PessoaId, RevendaId);

                string url = Url.Action("ListarRevenda", "Clientes", new { id = PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "revenda" });
            }
            ViewBag.PessoaId = PessoaId;
            ViewBag.RevendaList = new SelectList(_clienteAppService.GetAllPessoaJuridicaDeRevendas().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            return PartialView("_AdicionarRevenda");
        }

        public ActionResult DeletarRevenda(Guid? PessoaId, Guid? RevendaId)
        {
            if (RevendaId == null || PessoaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var revendaViewModel = _clienteAppService.GetRevendaById(RevendaId.Value);
            if (revendaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = PessoaId;
            return PartialView("_DeletarRevenda", revendaViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarRevenda")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarRevendaConfirmed(Guid PessoaId)
        {
            _clienteAppService.RemoveRevenda(PessoaId);

            string url = Url.Action("ListarRevenda", "Clientes", new { id = PessoaId });
            return Json(new { success = true, url = url, replaceTarget = "revenda" });
        }

        public ActionResult ObterImagemCliente(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.CLIENTES_IMAGE_PATH);

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        //ANEXOS

        public ActionResult ListarAnexos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Clientes";
            return PartialView("_AnexoList", _clienteAppService.GetById(id).AnexoList);
        }

        [Route("adicionar-anexo")]
        public ActionResult AdicionarAnexo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewData["_controller"] = "Clientes";
            return PartialView("_AdicionarAnexo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AddAnexo(PessoaId, Arquivo);

                string url = Url.Action("ListarAnexos", "Clientes", new { id = PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "anexo" });
            }
            ViewBag.PessoaId = PessoaId;
            return PartialView("_AdicionarAnexo");
        }

        public ActionResult DeletarAnexo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var anexoViewModel = _clienteAppService.GetAnexoById(id.Value);
            if (anexoViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = anexoViewModel.PessoaId;
            return PartialView("_DeletarAnexo", anexoViewModel);
        }

        [HttpPost, ActionName("DeletarAnexo")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarAnexoConfirmed(Guid id)
        {
            var pessoaId = _clienteAppService.GetAnexoById(id).PessoaId;
            _clienteAppService.RemoveAnexo(id);

            string url = Url.Action("ListarAnexos", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "anexo" });
        }

        //DEBITOS

        public ActionResult ListarBoletos(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var debitoViewModel = _clienteAppService.GetDebitoById(id.Value);
            if (debitoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_BoletoListCliente", debitoViewModel.BoletoList.OrderBy(b => b.Vencimento));
        }

        public ActionResult ListarDebitos(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.GetById(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DebitoList", clienteViewModel.DebitoList);
        }

        public ActionResult BaixarDebito(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var debitoViewModel = _clienteAppService.GetDebitoById(id.Value);
            if (debitoViewModel == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PessoaId = anexoViewModel.PessoaId;
            return PartialView("_BaixarDebitoCliente", debitoViewModel);
        }

        [HttpPost, ActionName("BaixarDebito")]
        [ValidateAntiForgeryToken]
        public ActionResult BaixarDebitoConfirmed(Guid id)
        {
            var pessoaId = _clienteAppService.GetDebitoById(id).ClienteId;
            _clienteAppService.BaixarDebito(id);

            string url = Url.Action("ListarDebitos", "Clientes", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "debito" });
        }

        //ANEXOS

        public ActionResult BaixarAnexo(Guid id)
        {
            var anexo = _clienteAppService.GetAnexoById(id);
            return File(anexo.Content, anexo.ContentType, anexo.FileName);
        }

        private void loadViewBags()
        {
            ViewBag.CnaeList = new SelectList(_clienteAppService.GetAllCnae().OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            ViewBag.ServicoList = new SelectList(_clienteAppService.GetAllServicos().OrderBy(c => c.Descricao), "ServicoId", "Descricao");
            ViewBag.RevendaList = new SelectList(_clienteAppService.GetAllPessoaJuridicaDeRevendas().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            ViewBag.RegimeApuracaoList = new SelectList(_clienteAppService.GetAllRegimeApuracao().OrderBy(c => c.Descricao), "RegimeApuracaoId", "Descricao");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
