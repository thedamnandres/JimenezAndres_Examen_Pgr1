using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JimenezAndres_Examen_Pgr1.Data;
using JimenezAndres_Examen_Pgr1.Models;

namespace JimenezAndres_Examen_Pgr1.Controllers
{
    public class CelularesController : Controller
    {
        private readonly JimenezAndres_Examen_Pgr1Context _context;

        public CelularesController(JimenezAndres_Examen_Pgr1Context context)
        {
            _context = context;
        }

        // GET: Celulares
        public async Task<IActionResult> Index()
        {
            var jimenezAndres_Examen_Pgr1Context = _context.Celular.Include(c => c.Cliente);
            return View(await jimenezAndres_Examen_Pgr1Context.ToListAsync());
        }

        // GET: Celulares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // GET: Celulares/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.AJimenez, "Id", "Nombre");
            return View();
        }

        // POST: Celulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Year,Precio,IdCliente")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.AJimenez, "Id", "Nombre", celular.IdCliente);
            return View(celular);
        }

        // GET: Celulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.AJimenez, "Id", "Nombre", celular.IdCliente);
            return View(celular);
        }

        // POST: Celulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Year,Precio,IdCliente")] Celular celular)
        {
            if (id != celular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celular.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.AJimenez, "Id", "Nombre", celular.IdCliente);
            return View(celular);
        }

        // GET: Celulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celular = await _context.Celular.FindAsync(id);
            if (celular != null)
            {
                _context.Celular.Remove(celular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
            return _context.Celular.Any(e => e.Id == id);
        }
    }
}
