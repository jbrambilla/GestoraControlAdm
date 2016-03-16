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
                return Json(new { success = true, url = url, replaceTarget = "endereco" });
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
                return Json(new { success = true, url = url, replaceTarget = "endereco" });
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
            return Json(new { success = true, url = url, replaceTarget = "endereco" });
        }

        //Contato
        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Empresas";
            return PartialView("_ContatoList", _empresaAppService.GetById(id).ContatoList);
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
                _empresaAppService.AddContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Empresas", new { id = contatoViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "contato" });
            }

            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            return PartialView("_AtualizarContato", _empresaAppService.GetContatoById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarContato(ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.UpdateContato(contatoViewModel);

                string url = Url.Action("ListarContatos", "Empresas", new { id = contatoViewModel.PessoaId });
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

            var contatoViewModel = _empresaAppService.GetContatoById(id.Value);
            if (contatoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarContato", contatoViewModel);
        }

        // POST: Empresas/Delete/5

        [HttpPost, ActionName("DeletarContato")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmed(Guid id)
        {
            var pessoaId = _empresaAppService.GetContatoById(id).PessoaId;
            _empresaAppService.RemoveContato(id);

            string url = Url.Action("ListarContatos", "Empresas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "contato" });
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

        //ANEXOS

        public ActionResult ListarAnexos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Empresas";
            return PartialView("_AnexoList", _empresaAppService.GetById(id).AnexoList);
        }

        [Route("adicionar-anexo")]
        public ActionResult AdicionarAnexo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewData["_controller"] = "Empresas";
            return PartialView("_AdicionarAnexo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.AddAnexo(PessoaId, Arquivo);

                string url = Url.Action("ListarAnexos", "Empresas", new { id = PessoaId });
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

            var anexoViewModel = _empresaAppService.GetAnexoById(id.Value);
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
            var pessoaId = _empresaAppService.GetAnexoById(id).PessoaId;
            _empresaAppService.RemoveAnexo(id);

            string url = Url.Action("ListarAnexos", "Empresas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "anexo" });
        }

        public ActionResult BaixarAnexo(Guid id)
        {
            var anexo = _empresaAppService.GetAnexoById(id);
            return File(anexo.Content, anexo.ContentType, anexo.FileName);
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
            ViewBag.CnaeList = new SelectList(_empresaAppService.GetAllCnae().OrderBy(c => c.Codigo), "CnaeId", "Display");
            ViewBag.RegimeApuracaoList = new SelectList(_empresaAppService.GetAllRegimeApuracao().OrderBy(c => c.Codigo), "RegimeApuracaoId", "Display");
            ViewBag.RegimeTributacaoList = new SelectList(_empresaAppService.GetAllRegimeTributacao().OrderBy(c => c.Codigo), "RegimeTributacaoId", "Display");
            ViewBag.NaturezaOperacaoList = new SelectList(_empresaAppService.GetAllNaturezaOperacao().OrderBy(c => c.Codigo), "NaturezaOperacaoId", "Display");
            ViewBag.EnquadramentoServicoList = new SelectList(_empresaAppService.GetAllEnquadramentoServico().OrderBy(c => c.Codigo), "EnquadramentoServicoId", "Display");
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
