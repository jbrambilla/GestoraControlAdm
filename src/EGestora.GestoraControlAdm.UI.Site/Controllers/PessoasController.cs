using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }        

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(_pessoaAppService.GetAll());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _pessoaAppService.GetById(id.Value);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = id.Value;
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaEnderecoViewModel pessoaEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                pessoaEnderecoViewModel = _pessoaAppService.Add(pessoaEnderecoViewModel);

                if (!pessoaEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in pessoaEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    loadViewBags();
                    return View(pessoaEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(pessoaEnderecoViewModel);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _pessoaAppService.GetById(id.Value);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }

            loadViewBags();
            return View(pessoaViewModel);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.Update(pessoaViewModel);
                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(pessoaViewModel);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModel pessoaViewModel = _pessoaAppService.GetById(id.Value);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _pessoaAppService.Remove(id);
            return RedirectToAction("Index");
        }


        //Endereço


        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Pessoas";
            return PartialView("_EnderecoList", _pessoaAppService.GetById(id).EnderecoList);
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
                enderecoViewModel = _pessoaAppService.AddEndereco(enderecoViewModel);

                if (!enderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in enderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return PartialView("_AdicionarEndereco", enderecoViewModel);
                }

                string url = Url.Action("ListarEnderecos", "Pessoas", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _pessoaAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Pessoas", new { id = enderecoViewModel.PessoaId });
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

            var enderecoViewModel = _pessoaAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Pessoas/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var pessoaId = _pessoaAppService.GetEnderecoById(id).PessoaId;
            _pessoaAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Pessoas", new { id = pessoaId });
            return Json(new { success = true, url = url });
        }

        //Contato
        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Pessoas";
            return PartialView("_ContatoList", _pessoaAppService.GetById(id).ContatoList);
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
                _pessoaAppService.AddContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Pessoas", new { id = contatoViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "contato" });
            }

            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            return PartialView("_AtualizarContato", _pessoaAppService.GetContatoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.UpdateContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Pessoas", new { id = contatoViewModel.PessoaId });
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

            var contatoViewModel = _pessoaAppService.GetContatoById(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarContato", contatoViewModel);
        }

        // POST: Pessoas/Delete/5

        [HttpPost, ActionName("DeletarContato")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmed(Guid id)
        {
            var pessoaId = _pessoaAppService.GetContatoById(id).PessoaId;
            _pessoaAppService.RemoveContato(id);

            string url = Url.Action("ListarContatos", "Pessoas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "contato" });
        }

        //ANEXOS

        public ActionResult ListarAnexos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Pessoas";
            return PartialView("_AnexoList", _pessoaAppService.GetById(id).AnexoList);
        }

        [Route("adicionar-anexo")]
        public ActionResult AdicionarAnexo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewData["_controller"] = "Pessoas";
            return PartialView("_AdicionarAnexo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.AddAnexo(PessoaId, Arquivo);

                string url = Url.Action("ListarAnexos", "Pessoas", new { id = PessoaId });
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

            var anexoViewModel = _pessoaAppService.GetAnexoById(id.Value);
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
            var pessoaId = _pessoaAppService.GetAnexoById(id).PessoaId;
            _pessoaAppService.RemoveAnexo(id);

            string url = Url.Action("ListarAnexos", "Pessoas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "anexo" });
        }

        public ActionResult BaixarAnexo(Guid id)
        {
            var anexo = _pessoaAppService.GetAnexoById(id);
            return File(anexo.Content, anexo.ContentType, anexo.FileName);
        }

        public ActionResult ObterImagemPessoa(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.PESSOAS_IMAGE_PATH);

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }


        private void loadViewBags()
        {
            ViewBag.TipoContatoList = _pessoaAppService.GetAllTipoContatos().OrderBy(tc => tc.Nome);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pessoaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}