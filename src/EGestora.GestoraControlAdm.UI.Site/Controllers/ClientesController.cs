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
            loadVierBags();
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
                    loadVierBags();
                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            loadVierBags();
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

        public ActionResult ObterImagemCliente(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.CLIENTES_IMAGE_PATH);

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        private void loadVierBags()
        {
            ViewBag.CnaeList = new SelectList(_clienteAppService.GetAllCnae().OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            ViewBag.ServicoList = new SelectList(_clienteAppService.GetAllServicos().OrderBy(c => c.Descricao), "ServicoId", "Descricao");
            ViewBag.RevendaList = new SelectList(_clienteAppService.GetAllPessoaJuridicaDeRevendas().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
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
