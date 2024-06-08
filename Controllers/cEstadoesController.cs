using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicaV1.Context;
using practicaV1.Models;

namespace practicaV1.Controllers
{
    public class cEstadoesController : Controller
    {
        private readonly HotelYCAContext _context;

        public cEstadoesController(HotelYCAContext context)
        {
            _context = context;
        }

        // GET: cEstadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tEstado.ToListAsync());
        }

        // GET: cEstadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado
                .FirstOrDefaultAsync(m => m.idEstado == id);
            if (cEstado == null)
            {
                return NotFound();
            }

            return View(cEstado);
        }

        // GET: cEstadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cEstadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstado,nombre")] cEstado cEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cEstado);
        }

        // GET: cEstadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado.FindAsync(id);
            if (cEstado == null)
            {
                return NotFound();
            }
            return View(cEstado);
        }

        // POST: cEstadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEstado,nombre")] cEstado cEstado)
        {
            if (id != cEstado.idEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cEstadoExists(cEstado.idEstado))
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
            return View(cEstado);
        }

        // GET: cEstadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado
                .FirstOrDefaultAsync(m => m.idEstado == id);
            if (cEstado == null)
            {
                return NotFound();
            }

            return View(cEstado);
        }

        // POST: cEstadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cEstado = await _context.tEstado.FindAsync(id);
            if (cEstado != null)
            {
                _context.tEstado.Remove(cEstado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cEstadoExists(int id)
        {
            return _context.tEstado.Any(e => e.idEstado == id);
        }
    }
}
