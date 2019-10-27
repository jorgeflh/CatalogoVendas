using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CatalogoVendas.Core.Models;
using CatalogoVendas.Core.Interfaces.Repositories;
using System.Collections;

namespace CatalogoVendas.Controllers
{
    public class TbSegmentoEmpresasController : Controller
    {
        private readonly ISegmentoEmpresaRepository segmentoEmpresaRepository;
        private readonly IEmpresaRepository empresaRepository;

        public TbSegmentoEmpresasController(ISegmentoEmpresaRepository segmentoEmpresaRepository, IEmpresaRepository empresaRepository)
        {
            this.segmentoEmpresaRepository = segmentoEmpresaRepository;
            this.empresaRepository = empresaRepository;
        }

        // GET: TbSegmentoEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await segmentoEmpresaRepository.GetSegmentosEmpresa());
        }

        // GET: TbSegmentoEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSegmentoEmpresa = await segmentoEmpresaRepository.GetSegmentoEmpresaById(id.Value);
            if (tbSegmentoEmpresa == null)
            {
                return NotFound();
            }

            return View(tbSegmentoEmpresa);
        }

        // GET: TbSegmentoEmpresas/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial");
            return View();
        }

        // POST: TbSegmentoEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSegmento,IdEmpresa,DesSegmento,Ativo")] TbSegmentoEmpresa tbSegmentoEmpresa)
        {
            if (ModelState.IsValid)
            {
                var companyFielWasCreated = await segmentoEmpresaRepository.InsertSegmentoEmpresa(tbSegmentoEmpresa);

                if (companyFielWasCreated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbSegmentoEmpresa.IdEmpresa);
            return View(tbSegmentoEmpresa);
        }

        // GET: TbSegmentoEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSegmentoEmpresa = await segmentoEmpresaRepository.GetSegmentoEmpresaById(id.Value);
            if (tbSegmentoEmpresa == null)
            {
                return NotFound();
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbSegmentoEmpresa.IdEmpresa);
            return View(tbSegmentoEmpresa);
        }

        // POST: TbSegmentoEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSegmento,IdEmpresa,DesSegmento,Ativo")] TbSegmentoEmpresa tbSegmentoEmpresa)
        {
            if (id != tbSegmentoEmpresa.IdSegmento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var companyFieldWasUpdated = await segmentoEmpresaRepository.UpdateSegmentoEmpresa(tbSegmentoEmpresa);
                if (companyFieldWasUpdated)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpresa"] = new SelectList(await empresaRepository.GetEmpresas(), "IdEmpresa", "RazaoSocial", tbSegmentoEmpresa.IdEmpresa);
            return View(tbSegmentoEmpresa);
        }

        // GET: TbSegmentoEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSegmentoEmpresa = await segmentoEmpresaRepository.GetSegmentoEmpresaById(id.Value);
            if (tbSegmentoEmpresa == null)
            {
                return NotFound();
            }

            return View(tbSegmentoEmpresa);
        }

        // POST: TbSegmentoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyFieldWasDeleted = await segmentoEmpresaRepository.DeleteSegmentoEmpresa(id);

            if (companyFieldWasDeleted)
                return RedirectToAction(nameof(Index));
            else
                return View(await segmentoEmpresaRepository.GetSegmentoEmpresaById(id));
        }
    }
}
