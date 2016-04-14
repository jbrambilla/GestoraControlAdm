using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class RevendasController : Controller
    {
        private readonly IRevendaAppService _revendaAppService;

        public RevendasController(IRevendaAppService revendaAppService)
        {
            _revendaAppService = revendaAppService;
        }

        // GET: Revendas
        public ActionResult Index()
        {
            return View(_revendaAppService.GetAll());
        }

        // GET: Revendas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevendaViewModel revendaViewModel = _revendaAppService.GetById(id.Value);
            if (revendaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = id;
            return View(revendaViewModel);
        }

        // GET: Revendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevendaEnderecoViewModel revendaEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                revendaEnderecoViewModel = _revendaAppService.Add(revendaEnderecoViewModel);

                if (!revendaEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in revendaEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(revendaEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            return View(revendaEnderecoViewModel);
        }

        // GET: Revendas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevendaViewModel revendaViewModel = _revendaAppService.GetById(id.Value);
            if (revendaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(revendaViewModel);
        }

        // POST: Revendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RevendaViewModel revendaViewModel)
        {
            if (ModelState.IsValid)
            {
                _revendaAppService.Update(revendaViewModel);
                return RedirectToAction("Index");
            }
            return View(revendaViewModel);
        }

        // GET: Revendas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevendaViewModel revendaViewModel = _revendaAppService.GetById(id.Value);
            if (revendaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(revendaViewModel);
        }

        // POST: Revendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _revendaAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Revendas";
            return PartialView("_EnderecoList", _revendaAppService.GetById(id).EnderecoList);
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
                _revendaAppService.AddEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Revendas", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _revendaAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _revendaAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Revendas", new { id = enderecoViewModel.PessoaId });
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

            var enderecoViewModel = _revendaAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Revendas/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var pessoaId = _revendaAppService.GetEnderecoById(id).PessoaId;
            _revendaAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Revendas", new { id = pessoaId });
            return Json(new { success = true, url = url });
        }

        //Contato
        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Revendas";
            return PartialView("_ContatoList", _revendaAppService.GetById(id).ContatoList);
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
                _revendaAppService.AddContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Revendas", new { id = contatoViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "contato" });
            }

            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            return PartialView("_AtualizarContato", _revendaAppService.GetContatoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _revendaAppService.UpdateContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Revendas", new { id = contatoViewModel.PessoaId });
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

            var contatoViewModel = _revendaAppService.GetContatoById(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarContato", contatoViewModel);
        }

        // POST: Revendas/Delete/5

        [HttpPost, ActionName("DeletarContato")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmed(Guid id)
        {
            var pessoaId = _revendaAppService.GetContatoById(id).PessoaId;
            _revendaAppService.RemoveContato(id);

            string url = Url.Action("ListarContatos", "Revendas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "contato" });
        }

        //ANEXOS

        public ActionResult ListarAnexos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Revendas";
            return PartialView("_AnexoList", _revendaAppService.GetById(id).AnexoList);
        }

        [Route("adicionar-anexo")]
        public ActionResult AdicionarAnexo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewData["_controller"] = "Revendas";
            return PartialView("_AdicionarAnexo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            if (ModelState.IsValid)
            {
                _revendaAppService.AddAnexo(PessoaId, Arquivo);

                string url = Url.Action("ListarAnexos", "Revendas", new { id = PessoaId });
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

            var anexoViewModel = _revendaAppService.GetAnexoById(id.Value);
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
            var pessoaId = _revendaAppService.GetAnexoById(id).PessoaId;
            _revendaAppService.RemoveAnexo(id);

            string url = Url.Action("ListarAnexos", "Revendas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "anexo" });
        }

        public ActionResult BaixarAnexo(Guid id)
        {
            var anexo = _revendaAppService.GetAnexoById(id);
            return File(anexo.Content, anexo.ContentType, anexo.FileName);
        }

        public ActionResult ObterImagemRevenda(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.REVENDAS_IMAGE_PATH);

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
                _revendaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
