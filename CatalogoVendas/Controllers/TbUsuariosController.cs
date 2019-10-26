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
    public class TbUsuariosController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;

        public TbUsuariosController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        // GET: TbUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await usuarioRepository.GetUsuarios());
        }

        // GET: TbUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuario = await usuarioRepository.GetUsuarioById(id.Value);

            if (tbUsuario == null)
            {
                return NotFound();
            }

            return View(tbUsuario);
        }

        // GET: TbUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nome,Cpf,Rg,Telefone,DesLogin,Senha")] TbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                var userWasCreated = await usuarioRepository.InsertUsuario(tbUsuario);

                if (userWasCreated)
                    return RedirectToAction(nameof(Index));
            }
            return View(tbUsuario);
        }

        // GET: TbUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuario = await usuarioRepository.GetUsuarioById(id.Value);
            if (tbUsuario == null)
            {
                return NotFound();
            }
            return View(tbUsuario);
        }

        // POST: TbUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nome,Cpf,Rg,Telefone,DesLogin,Senha")] TbUsuario tbUsuario)
        {
            if (id != tbUsuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var userWasUpdated = await usuarioRepository.UpdateUsuario(tbUsuario);

                if (userWasUpdated)
                    return RedirectToAction(nameof(Index));
            }
            return View(tbUsuario);
        }

        // GET: TbUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuario = await usuarioRepository.GetUsuarioById(id.Value);
            if (tbUsuario == null)
            {
                return NotFound();
            }

            return View(tbUsuario);
        }

        // POST: TbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userWasDeleted = await usuarioRepository.DeleteUsuario(id);

            if (userWasDeleted)
                return RedirectToAction(nameof(Index));
            else
            {
                var user = usuarioRepository.GetUsuarioById(id);
                return View(user);
            }

        }
    }
}
