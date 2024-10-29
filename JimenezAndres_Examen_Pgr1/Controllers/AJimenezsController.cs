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
    public class AJimenezsController : Controller
    {
        private readonly JimenezAndres_Examen_Pgr1Context _context;

        public AJimenezsController(JimenezAndres_Examen_Pgr1Context context)
        {
            _context = context;
        }

        // GET: AJimenezs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AJimenez.ToListAsync());
        }

        // GET: AJimenezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aJimenez = await _context.AJimenez
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aJimenez == null)
            {
                return NotFound();
            }

            return View(aJimenez);
        }

        // GET: AJimenezs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AJimenezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Dinero,MayorEdad,Cumpleanos")] AJimenez aJimenez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aJimenez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aJimenez);
        }

        // GET: AJimenezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aJimenez = await _context.AJimenez.FindAsync(id);
            if (aJimenez == null)
            {
                return NotFound();
            }
            return View(aJimenez);
        }

        // POST: AJimenezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Dinero,MayorEdad,Cumpleanos")] AJimenez aJimenez)
        {
            if (id != aJimenez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aJimenez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AJimenezExists(aJimenez.Id))
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
            return View(aJimenez);
        }

        // GET: AJimenezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aJimenez = await _context.AJimenez
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aJimenez == null)
            {
                return NotFound();
            }

            return View(aJimenez);
        }

        // POST: AJimenezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aJimenez = await _context.AJimenez.FindAsync(id);
            if (aJimenez != null)
            {
                _context.AJimenez.Remove(aJimenez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AJimenezExists(int id)
        {
            return _context.AJimenez.Any(e => e.Id == id);
        }
    }
}
