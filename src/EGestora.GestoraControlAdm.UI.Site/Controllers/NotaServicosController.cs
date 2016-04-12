﻿using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using Rotativa.Core;
using Rotativa.Core.Options;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class NotaServicosController : Controller
    {
        private readonly INotaServicoAppService _notaServicoAppService;

        public NotaServicosController(INotaServicoAppService notaServicoAppService)
        {
            _notaServicoAppService = notaServicoAppService;
        }

        // GET: Cnaes
        public ActionResult Index()
        {
            return View(_notaServicoAppService.GetAll());
        }

        // GET: Cnaes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notaServicoViewModel);
        }

        // GET: Cnaes/Create
        public ActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        // POST: Cnaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotaServicoDebitoViewModel notaServicoDebitoViewModel)
        {
            if (ModelState.IsValid)
            {
                notaServicoDebitoViewModel = _notaServicoAppService.Add(notaServicoDebitoViewModel);
                if (!notaServicoDebitoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in notaServicoDebitoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    LoadViewBags();
                    return View(notaServicoDebitoViewModel);
                }

                if (!EnviarEmail(notaServicoDebitoViewModel))
                {
                    return View(notaServicoDebitoViewModel);
                }

                return RedirectToAction("Index");
            }

            LoadViewBags();
            return View(notaServicoDebitoViewModel);
        }

        // GET: Cnaes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }

            LoadViewBags();
            return View(notaServicoViewModel);
        }

        // POST: Cnaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotaServicoViewModel notaServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                notaServicoViewModel = _notaServicoAppService.Update(notaServicoViewModel);
                if (!notaServicoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in notaServicoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    LoadViewBags();
                    return View(notaServicoViewModel);
                }

                if (!EnviarEmail(notaServicoViewModel))
                {
                    return View(notaServicoViewModel);
                }

                return RedirectToAction("Index");
            }
            LoadViewBags();
            return View(notaServicoViewModel);
        }

        // GET: Cnaes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notaServicoViewModel);
        }

        // POST: Cnaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _notaServicoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult ObterValoresPorCliente(Guid id)
        {
            var cliente = _notaServicoAppService.ObterClientePorId(id);
            return Json(new { discriminacaoServicos = cliente.DiscriminacaoServicos, valorTotal = cliente.ValorTotalServicos }, JsonRequestBehavior.AllowGet);
        }

        private bool EnviarEmail(NotaServicoDebitoViewModel notaServicoDebitoViewModel)
        {
            var NfseViewAsPdf = EmitirPdf(notaServicoDebitoViewModel.NotaServicoId);
            if (!notaServicoDebitoViewModel.EnviarEmail)
            {
                return false;
            }

            notaServicoDebitoViewModel.PdfNfse = NfseViewAsPdf.BuildPdf(ControllerContext);
            if (_notaServicoAppService.EnviarEmail(notaServicoDebitoViewModel))
            {
                return true;
            }

            ModelState.AddModelError(string.Empty, "Erro ao enviar e-mail.");
            LoadViewBags();
            return false;
        }

        private bool EnviarEmail(NotaServicoViewModel notaServicoViewModel)
        {
            var NfseViewAsPdf = EmitirPdf(notaServicoViewModel.NotaServicoId);
            if (!notaServicoViewModel.EnviarEmail)
            {
                return false;
            }

            notaServicoViewModel.PdfNfse = NfseViewAsPdf.BuildPdf(ControllerContext);
            if (_notaServicoAppService.EnviarEmail(notaServicoViewModel))
            {
                return true;
            }

            ModelState.AddModelError(string.Empty, "Erro ao enviar e-mail.");
            LoadViewBags();
            return false;
        }

        private ViewAsPdf EmitirPdf(Guid id)
        {
            var notaServico = _notaServicoAppService.GetById(id);

            return new ViewAsPdf()
            {
                ViewName = "EmitirNota",
                Model = notaServico,
                RotativaOptions = new DriverOptions()
                {
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 }
                }
            };
        }

        private void LoadViewBags()
        {
            var empresa = _notaServicoAppService.GetEmpresaAtiva();
            var empresaList = new List<PessoaJuridicaViewModel>();
            empresaList.Add(empresa.PessoaJuridica);

            ViewBag.ClienteList = new SelectList(_notaServicoAppService.GetAllClientes().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            ViewBag.Empresa = new SelectList(empresaList, "PessoaId", "RazaoSocial");
            ViewBag.Aliquota = empresa.Aliquota;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notaServicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

