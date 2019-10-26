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
    public class TbEmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public TbEmpresasController(IEmpresaRepository empresaRepository, IUsuarioRepository usuarioRepository)
        {
            this.empresaRepository = empresaRepository;
            this.usuarioRepository = usuarioRepository;
        }

        // GET: TbEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await empresaRepository.GetEmpresas());
        }

        // GET: TbEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmpresa = await empresaRepository.GetEmpresaById(id.Value);
            if (tbEmpresa == null)
            {
                return NotFound();
            }

            return View(tbEmpresa);
        }

        // GET: TbEmpresas/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Cpf");
            return View();
        }

        // POST: TbEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,IdUsuarioCadastro,RazaoSocial,Cnpj,Endereco,Telefone")] TbEmpresa tbEmpresa)
        {
            if (ModelState.IsValid)
            {
                var companyWasCreated = await empresaRepository.InsertEmpresa(tbEmpresa);
                if (companyWasCreated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Cpf", tbEmpresa.IdUsuarioCadastro);
            return View(tbEmpresa);
        }

        // GET: TbEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmpresa = await empresaRepository.GetEmpresaById(id.Value);
            if (tbEmpresa == null)
            {
                return NotFound();
            }
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Cpf", tbEmpresa.IdUsuarioCadastro);
            return View(tbEmpresa);
        }

        // POST: TbEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpresa,IdUsuarioCadastro,RazaoSocial,Cnpj,Endereco,Telefone")] TbEmpresa tbEmpresa)
        {
            if (id != tbEmpresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var companyWasUpdated = await empresaRepository.UpdateEmpresa(tbEmpresa);
                if (companyWasUpdated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Cpf", tbEmpresa.IdUsuarioCadastro);
            return View(tbEmpresa);
        }

        // GET: TbEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmpresa = await empresaRepository.GetEmpresaById(id.Value);
            if (tbEmpresa == null)
            {
                return NotFound();
            }

            return View(tbEmpresa);
        }

        // POST: TbEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyWasDeleted = await empresaRepository.DeleteEmpresa(id);

            if (companyWasDeleted)
                return RedirectToAction(nameof(Index));
            else
                return View(empresaRepository.GetEmpresaById(id));
        }
    }
}
