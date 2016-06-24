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

        public ActionResult Index()
        {
            return View(_pessoaAppService.GetAll());
        }

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
            return View(pessoaViewModel);
        }

        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                pessoaViewModel = _pessoaAppService.Add(pessoaViewModel);

                //if (!pessoaViewModel.ValidationResult.IsValid)
                //{
                //    foreach (var erro in pessoaViewModel.ValidationResult.Erros)
                //    {
                //        ModelState.AddModelError(string.Empty, erro.Message);
                //    }
                //    loadViewBags();
                //    return View(pessoaViewModel);
                //}
                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(pessoaViewModel);
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

            LoadViewBagsEditar(id);
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
            LoadViewBagsEditar(pessoaViewModel.PessoaId);
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
        public ActionResult ListaSimplesEndereco(Guid id)
        {
            return PartialView("_EnderecoListSimple", _pessoaAppService.GetById(id).EnderecoList);
        }

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

                var enderecoPrincipal = _pessoaAppService.GetById(enderecoViewModel.PessoaId).EnderecoList.FirstOrDefault(e => e.Principal);
                var enderecoPrincipalCompleto = enderecoPrincipal != null ? enderecoPrincipal.EnderecoCompleto : "";
                string url = Url.Action("ListarEnderecos", "Pessoas", new { id = enderecoViewModel.PessoaId });
                return Json(new { success = true, url = url, principal = enderecoPrincipalCompleto });
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
        public ActionResult ListaSimplesContato(Guid id)
        {
            return PartialView("_ContatoListSimple", _pessoaAppService.GetById(id).ContatoList);
        }

        public ActionResult ListarContatos(Guid id)
        {
            ViewBag.PessoaId = id;
            ViewData["_controller"] = "Pessoas";
            return PartialView("_ContatoList", _pessoaAppService.GetById(id).ContatoList);
        }

        [Route("adicionar-contato")]
        public ActionResult AdicionarContato(Guid id)
        {
            loadViewBags();
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
            loadViewBags();
            return PartialView("_AdicionarContato", contatoViewModel);
        }

        public ActionResult AtualizarContato(Guid id)
        {
            loadViewBags();
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
            loadViewBags();
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

        //CNAE

        public ActionResult ListarCnaes(Guid id)
        {
            ViewBag.PessoaId = id;

            return PartialView("_CnaeList", _pessoaAppService.GetById(id).PessoaJuridica.CnaeList);
        }

        [Route("alterar-cnae-principal")]
        public ActionResult AlterarCnaePrincipal(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(id.Value).OrderBy(c => c.Codigo), "CnaeId", "Display");
            return PartialView("_AlterarCnaePrincipal", _pessoaAppService.GetById(id.Value).PessoaJuridica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarCnaePrincipal(PessoaJuridicaViewModel pessoaJuridicaViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.UpdatePessoaJuridica(pessoaJuridicaViewModel);

                string url = Url.Action("ListarCnaes", "Pessoas", new { id = pessoaJuridicaViewModel.PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "cnae" });
            }
            ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(pessoaJuridicaViewModel.PessoaId).OrderBy(c => c.Codigo), "CnaeId", "Display");
            return PartialView("_AlterarCnaePrincipal", pessoaJuridicaViewModel);
        }

        [Route("adicionar-cnae")]
        public ActionResult AdicionarCnae(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PessoaId = id.Value;
            ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(id.Value).OrderBy(c => c.Codigo), "CnaeId", "Display");
            return PartialView("_AdicionarCnae");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarCnae(Guid PessoaId, Guid CnaeId)
        {
            if (ModelState.IsValid)
            {
                if (!_pessoaAppService.AddCnae(CnaeId, PessoaId))
                {
                    ModelState.AddModelError(string.Empty, "Não é possível adicionar um Cnae igual ao Principal.");
                    ViewBag.PessoaId = PessoaId;
                    ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(PessoaId).OrderBy(c => c.Codigo), "CnaeId", "Display");
                    return PartialView("_AdicionarCnae");
                }

                string url = Url.Action("ListarCnaes", "Pessoas", new { id = PessoaId });
                return Json(new { success = true, url = url, replaceTarget = "cnae" });
            }
            ViewBag.PessoaId = PessoaId;
            ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(PessoaId).OrderBy(c => c.Codigo), "CnaeId", "Display");
            return PartialView("_AdicionarCnae");
        }

        public ActionResult DeletarCnae(Guid? id, Guid? pessoaId)
        {
            if (id == null || pessoaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cnaeViewModel = _pessoaAppService.GetCnaeById(id.Value);
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
            _pessoaAppService.RemoveCnae(id, pessoaId);

            string url = Url.Action("ListarCnaes", "Pessoas", new { id = pessoaId });
            return Json(new { success = true, url = url, replaceTarget = "cnae" });
        }

        //FUNCIONARIOS

        public ActionResult ListarFuncionarios(Guid id)
        {
            ViewBag.PessoaId = id;
            return PartialView("_FuncionarioList", _pessoaAppService.GetById(id).PessoaJuridica.FuncionarioList);
        }

        [Route("adicionar-funcionario")]
        public ActionResult AdicionarFuncionario(Guid id)
        {
            LoadViewBagsFuncionarios(id);
            return PartialView("_AdicionarFuncionario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.AddFuncionario(funcionarioViewModel);

                //if (!enderecoViewModel.ValidationResult.IsValid)
                //{
                //    foreach (var erro in enderecoViewModel.ValidationResult.Erros)
                //    {
                //        ModelState.AddModelError(string.Empty, erro.Message);
                //    }

                //    return PartialView("_AdicionarEndereco", enderecoViewModel);
                //}

                string url = Url.Action("ListarFuncionarios", "Pessoas", new { id = funcionarioViewModel.PessoaJuridicaId });
                return Json(new { success = true, url = url, replaceTarget = "funcionario" });
            }
            LoadViewBagsFuncionarios(funcionarioViewModel.PessoaId);
            return PartialView("_AdicionarFuncionario", funcionarioViewModel);
        }

        public ActionResult AtualizarFuncionario(Guid id)
        {
            var funcionarioViewModel = _pessoaAppService.GetFuncionarioById(id);
            LoadViewBagsFuncionarios(funcionarioViewModel.PessoaJuridicaId);
            return PartialView("_AtualizarFuncionario", funcionarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarFuncionario(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.UpdateFuncionario(funcionarioViewModel);

                string url = Url.Action("ListarFuncionarios", "Pessoas", new { id = funcionarioViewModel.PessoaJuridicaId });
                return Json(new { success = true, url = url, replaceTarget = "funcionario" });
            }
            LoadViewBagsFuncionarios(funcionarioViewModel.PessoaJuridicaId);
            return PartialView("_AtualizarFuncionario", funcionarioViewModel);
        }

        public ActionResult RemoverFuncionario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarioViewModel = _pessoaAppService.GetFuncionarioById(id.Value);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_RemoverFuncionario", funcionarioViewModel);
        }

        // POST: Pessoas/Delete/5

        [HttpPost, ActionName("RemoverFuncionario")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverFuncionarioConfirmed(Guid id)
        {
            var pessoaJuridicaId = _pessoaAppService.GetFuncionarioById(id).PessoaJuridicaId;
            _pessoaAppService.RemoveFuncionario(id);

            string url = Url.Action("ListarFuncionarios", "Pessoas", new { id = pessoaJuridicaId });
            return Json(new { success = true, url = url, replaceTarget = "funcionario" });
        }

        public ActionResult DetalhesFuncionario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioViewModel = _pessoaAppService.GetFuncionarioById(id.Value);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetalhesFuncionario", funcionarioViewModel);
        }

        //PROPRIETÁRIOS

        public ActionResult ListarProprietarios(Guid id)
        {
            ViewBag.PessoaId = id;
            return PartialView("_ProprietarioList", _pessoaAppService.GetById(id).PessoaJuridica);
        }

        [Route("adicionar-proprietario")]
        public ActionResult AdicionarProprietario(Guid id)
        {
            LoadViewBagsFuncionarios(id);
            return PartialView("_AdicionarProprietario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarProprietario(ProprietarioViewModel proprietarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.AddProprietario(proprietarioViewModel);

                string url = Url.Action("ListarProprietarios", "Pessoas", new { id = proprietarioViewModel.PessoaJuridicaId });
                return Json(new { success = true, url = url, replaceTarget = "proprietario" });
            }
            LoadViewBagsFuncionarios(proprietarioViewModel.PessoaId);
            return PartialView("_AdicionarProprietario", proprietarioViewModel);
        }

        public ActionResult AtualizarProprietario(Guid id)
        {
            var proprietarioViewModel = _pessoaAppService.GetProprietarioById(id);
            LoadViewBagsFuncionarios(proprietarioViewModel.PessoaJuridicaId);
            return PartialView("_AtualizarProprietario", proprietarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarProprietario(ProprietarioViewModel proprietarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.UpdateProprietario(proprietarioViewModel);

                string url = Url.Action("ListarProprietarios", "Pessoas", new { id = proprietarioViewModel.PessoaJuridicaId });
                return Json(new { success = true, url = url, replaceTarget = "proprietario" });
            }
            LoadViewBagsFuncionarios(proprietarioViewModel.PessoaJuridicaId);
            return PartialView("_AtualizarProprietario", proprietarioViewModel);
        }

        public ActionResult RemoverProprietario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var proprietarioViewModel = _pessoaAppService.GetProprietarioById(id.Value);
            if (proprietarioViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_RemoverProprietario", proprietarioViewModel);
        }

        // POST: Pessoas/Delete/5

        [HttpPost, ActionName("RemoverProprietario")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverProprietarioConfirmed(Guid id)
        {
            var pessoaJuridicaId = _pessoaAppService.GetProprietarioById(id).PessoaJuridicaId;
            _pessoaAppService.RemoveProprietario(id);

            string url = Url.Action("ListarProprietarios", "Pessoas", new { id = pessoaJuridicaId });
            return Json(new { success = true, url = url, replaceTarget = "proprietario" });
        }

        public ActionResult DetalhesProprietario(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proprietarioViewModel = _pessoaAppService.GetProprietarioById(id.Value);
            if (proprietarioViewModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetalhesProprietario", proprietarioViewModel);
        }

        public ActionResult ObterImagemPessoa(Guid id)
        {
            var foto = ImagemUtil.ObterImagem(id, FilePathConstants.PESSOAS_IMAGE_PATH);

            if (foto == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return File("~/Content/img/avatars/male.png", "image/jpeg");
            }

            return File(foto, "image/jpeg");
        }

        private void LoadViewBagsFuncionarios(Guid id)
        {
            ViewBag.PessoaJuridicaId = id;
            ViewBag.PessoaJuridicaList = new SelectList(_pessoaAppService.GetAllPessoaJuridica().Where(pf => pf.PessoaId != id).OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            ViewBag.PessoaFisicaList = new SelectList(_pessoaAppService.GetAllPessoaFisica().Where(pf => pf.PessoaId != id).OrderBy(c => c.Nome), "PessoaId", "Nome");
            ViewBag.CargoList = new SelectList(_pessoaAppService.GetAllCargo().OrderBy(c => c.Nome), "CargoId", "Nome");
        }

        private void loadViewBags()
        {
            ViewBag.TipoContatoList = _pessoaAppService.GetAllTipoContatos().OrderBy(tc => tc.Nome);
            ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnae().OrderBy(c => c.Codigo), "CnaeId", "Display");
            ViewBag.RegimeImpostoList = new SelectList(_pessoaAppService.GetAllRegimeImpostos().OrderBy(r => r.Descricao), "RegimeImpostoId", "Descricao");
            ViewBag.ProfissaoList = new SelectList(_pessoaAppService.GetAllProfissoes().OrderBy(c => c.Nome), "ProfissaoId", "Nome");
        }

        private void LoadViewBagsEditar(Guid? id)
        {
            var pessoa = _pessoaAppService.GetById(id.Value);

            ViewBag.RegimeImpostoList = new SelectList(_pessoaAppService.GetAllRegimeImpostos().OrderBy(r => r.Descricao), "RegimeImpostoId", "Descricao");
            if (pessoa.IsPessoaJuridica)
            {
                ViewBag.CnaeList = new SelectList(_pessoaAppService.GetAllCnaeOutPessoa(id.Value).OrderBy(c => c.Codigo), "CnaeId", "Display");
            }
            ViewBag.ProfissaoList = new SelectList(_pessoaAppService.GetAllProfissoes().OrderBy(c => c.Nome), "ProfissaoId", "Nome");
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