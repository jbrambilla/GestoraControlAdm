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
    public class EmpresasController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresasController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        // GET: Empresas
        public ActionResult Index()
        {
            var empresas = _empresaAppService.GetAll();
            if (empresas.Any(e => e.Ativo))
            {
                return RedirectToAction("Details", new { id = empresas.First(e => e.Ativo).PessoaId });
            }
            return View();
        }

        // GET: Empresas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(empresaViewModel);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaEnderecoViewModel empresaEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                empresaEnderecoViewModel = _empresaAppService.Add(empresaEnderecoViewModel);

                if (!empresaEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in empresaEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    loadViewBags();
                    return View(empresaEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(empresaEnderecoViewModel);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(empresaViewModel);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresaViewModel)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.Update(empresaViewModel);
                return RedirectToAction("Index");
            }
            return View(empresaViewModel);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(empresaViewModel);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _empresaAppService.Remove(id);
            return RedirectToAction("Index");
        }

        //Endereço


        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Empresas";
            return PartialView("_EnderecoList", _empresaAppService.GetById(id).EnderecoList);
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
                _empresaAppService.AddEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Empresas", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _empresaAppService.GetEnderecoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.UpdateEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Empresas", new { id = enderecoViewModel.PessoaId });
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

            var enderecoViewModel = _empresaAppService.GetEnderecoById(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Empresas/Delete/5

        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var pessoaId = _empresaAppService.GetEnderecoById(id).PessoaId;
            _empresaAppService.RemoveEndereco(id);

            string url = Url.Action("ListarEnderecos", "Empresas", new { id = pessoaId });
            return Json(new { success = true, url = url });
        }

        //CNAE

        public ActionResult ListarCnaes(Guid id)
        {
            ViewBag.PessoaId = id;

            return PartialView("_CnaeList", _empresaAppService.GetById(id).CnaeList);
        }

        [Route("adicionar-cnae")]
        public ActionResult AdicionarCnae(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.CnaeList = new SelectList(_empresaAppService.GetAllCnaeOutPessoa(id.Value).OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            return PartialView("_AdicionarCnae");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarCnae(Guid PessoaId, Guid CnaeId)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.AddCnae(CnaeId, PessoaId);

                string url = Url.Action("ListarCnaes", "Empresas", new { id = PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "cnae" });
            }
            ViewBag.PessoaId = PessoaId;
            ViewBag.CnaeList = new SelectList(_empresaAppService.GetAllCnaeOutPessoa(PessoaId).OrderBy(c => c.Codigo), "CnaeId", "Descricao");
            return PartialView("_AdicionarCnae");
        }

        public ActionResult DeletarCnae(Guid? id, Guid? pessoaId)
        {
            if (id == null || pessoaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cnaeViewModel = _empresaAppService.GetCnaeById(id.Value);
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
            _empresaAppService.RemoveCnae(id, pessoaId);

            string url = Url.Action("ListarCnaes", "Empresas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "cnae" });
        }

        //FUNCIONÁRIOS

        public ActionResult ListarFuncionarios(Guid id)
        {
            ViewBag.PessoaId = id;
            return PartialView("_FuncionarioList", _empresaAppService.GetById(id).FuncionarioList.Where(f => f.Ativo).ToList());
        }

        [Route("adicionar-funcionario")]
        public ActionResult AdicionarFuncionario(Guid id)
        {
            ViewBag.EmpresaId = id;
            return PartialView("_AdicionarFuncionario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarFuncionario(FuncionarioEnderecoViewModel funcionarioEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                funcionarioEnderecoViewModel = _empresaAppService.AddFuncionario(funcionarioEnderecoViewModel);

                if (!funcionarioEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in funcionarioEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return PartialView("_AdicionarFuncionario", funcionarioEnderecoViewModel);
                }

                string url = Url.Action("ListarFuncionarios", "Empresas", new { id = funcionarioEnderecoViewModel.EmpresaId });
                return Json(new { success = true, url = url, replaceTarget = "funcionario" });
            }

            return PartialView("_AdicionarFuncionario", funcionarioEnderecoViewModel);
        }

        public ActionResult AtualizarFuncionario(Guid id)
        {
            return PartialView("_AtualizarFuncionario", _empresaAppService.GetFuncionarioById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                funcionarioViewModel = _empresaAppService.UpdateFuncionario(funcionarioViewModel);

                string url = Url.Action("ListarFuncionarios", "Empresas", new { id = funcionarioViewModel.EmpresaId });
                return Json(new { success = true, url = url, replaceTarget = "funcionario" });
            }

            return PartialView("_AtualizarFuncionario", funcionarioViewModel);
        }

        public ActionResult DeletarFuncionario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarioViewModel = _empresaAppService.GetFuncionarioById(id.Value);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarFuncionario", funcionarioViewModel);
        }

        // POST: Empresas/Delete/5

        [HttpPost, ActionName("DeletarFuncionario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarFuncionarioConfirmed(Guid id)
        {
            var empresaId = _empresaAppService.GetFuncionarioById(id).EmpresaId;
            _empresaAppService.RemoveFuncionario(id);

            string url = Url.Action("ListarFuncionarios", "Empresas", new { id = empresaId });
            return Json(new { success = true, url = url, replaceTarget = "funcionario" });
        }

        public ActionResult DetalhesFuncionario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarioViewModel = _empresaAppService.GetFuncionarioById(id.Value);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetalhesFuncionario", funcionarioViewModel);
        }

        public ActionResult ObterImagemEmpresa(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.EMPRESAS_IMAGE_PATH);

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        private void loadViewBags()
        {
            ViewBag.CnaeList = new SelectList(_empresaAppService.GetAllCnae().OrderBy(c => c.Codigo), "CnaeId", "Descricao");
        }

        public ActionResult ObterImagemFuncionario(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.FUNCIONARIOS_IMAGE_PATH);

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
                _empresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
