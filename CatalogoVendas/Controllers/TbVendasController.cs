using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogoVendas.Core.Models;
using CatalogoVendas.Infra.Context;
using CatalogoVendas.Core.Interfaces.Repositories;

namespace CatalogoVendas.Controllers
{
    public class TbVendasController : Controller
    {
        private readonly IVendasRepository vendasRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public TbVendasController(
            IVendasRepository vendasRepository,
            IEmpresaRepository empresaRepository,
            IUsuarioRepository usuarioRepository)
        {
            this.vendasRepository = vendasRepository;
            this.empresaRepository = empresaRepository;
            this.usuarioRepository = usuarioRepository;
        }

        // GET: TbVendas
        public async Task<IActionResult> Index()
        {
            return View(await vendasRepository.GetVendas());
        }

        // GET: TbVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await vendasRepository.GetVendaById(id.Value);
            if (tbVendas == null)
            {
                return NotFound();
            }

            return View(tbVendas);
        }

        // GET: TbVendas/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial");
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome");
            return View();
        }

        // POST: TbVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdEmpresa,IdUsuarioCadastro,ValorVenda,DataVenda,EmitidoNf")] TbVendas tbVendas)
        {
            if (ModelState.IsValid)
            {
                var orderWasCreated = await vendasRepository.InsertVenda(tbVendas);
                if (orderWasCreated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbVendas.IdEmpresa);
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbVendas.IdUsuarioCadastro);
            return View(tbVendas);
        }

        // GET: TbVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await vendasRepository.GetVendaById(id.Value);
            if (tbVendas == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbVendas.IdEmpresa);
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbVendas.IdUsuarioCadastro);
            return View(tbVendas);
        }

        // POST: TbVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdEmpresa,IdUsuarioCadastro,ValorVenda,DataVenda,EmitidoNf")] TbVendas tbVendas)
        {
            if (id != tbVendas.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var orderWasUpdated = await vendasRepository.UpdateVenda(tbVendas);

                if (orderWasUpdated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbVendas.IdEmpresa);
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbVendas.IdUsuarioCadastro);
            return View(tbVendas);
        }

        // GET: TbVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await vendasRepository.GetVendaById(id.Value);
            if (tbVendas == null)
            {
                return NotFound();
            }

            return View(tbVendas);
        }

        // POST: TbVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderWasDeleted = await vendasRepository.DeleteVenda(id);

            if (orderWasDeleted)
                return RedirectToAction(nameof(Index));
            else
                return View(await vendasRepository.GetVendaById(id));
        }
    }
}
