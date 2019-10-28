using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CatalogoVendas.Core.Models;
using CatalogoVendas.Core.Interfaces.Repositories;
using CatalogoVendas.Core.Interfaces.Services;

namespace CatalogoVendas.Controllers
{
    public class TbEmpresasController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IEmpresaService empresaService;

        public TbEmpresasController(
            IEmpresaRepository empresaRepository,
            IUsuarioRepository usuarioRepository,
            IEmpresaService empresaService)
        {
            this.empresaRepository = empresaRepository;
            this.usuarioRepository = usuarioRepository;
            this.empresaService = empresaService;
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
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome");
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
                var companyWasCreated = await empresaService.InsertCompany(tbEmpresa);
                if (companyWasCreated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbEmpresa.IdUsuarioCadastro);
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
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbEmpresa.IdUsuarioCadastro);
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
                var companyWasUpdated = await empresaService.UpdateCompany(tbEmpresa);
                if (companyWasUpdated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarioCadastro"] = new SelectList(await usuarioRepository.GetUsuarios(), "IdUsuario", "Nome", tbEmpresa.IdUsuarioCadastro);
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
