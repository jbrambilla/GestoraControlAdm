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
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedoresController(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(_fornecedorAppService.GetAll());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.GetById(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorEnderecoViewModel fornecedorEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorEnderecoViewModel = _fornecedorAppService.Add(fornecedorEnderecoViewModel);

                if (!fornecedorEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in fornecedorEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(fornecedorEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            return View(fornecedorEnderecoViewModel);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.GetById(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                _fornecedorAppService.Update(fornecedorViewModel);
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = _fornecedorAppService.GetById(id.Value);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _fornecedorAppService.Remove(id);
            return RedirectToAction("Index");
        }

        //Endereço


        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Fornecedores";
            return PartialView("_EnderecoList", _fornecedorAppService.GetById(id).EnderecoList);
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
                _fornecedorAppService.AddEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Fornecedores", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _fornecedorAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _fornecedorAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Fornecedores", new { id = enderecoViewModel.PessoaId });
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

            var enderecoViewModel = _fornecedorAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Fornecedores/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var pessoaId = _fornecedorAppService.GetEnderecoById(id).PessoaId;
            _fornecedorAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Fornecedores", new { id = pessoaId });
            return Json(new { success = true, url = url });
        }

        public ActionResult ObterImagemFornecedor(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.FORNECEDORES_IMAGE_PATH);

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fornecedorAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
