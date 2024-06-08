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
    public class cTipoHabitacionsController : Controller
    {
        private readonly HotelYCAContext _context;

        public cTipoHabitacionsController(HotelYCAContext context)
        {
            _context = context;
        }

        // GET: cTipoHabitacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.tTipoHabitacion.ToListAsync());
        }

        // GET: cTipoHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTipoHabitacion = await _context.tTipoHabitacion
                .FirstOrDefaultAsync(m => m.idTipo == id);
            if (cTipoHabitacion == null)
            {
                return NotFound();
            }

            return View(cTipoHabitacion);
        }

        // GET: cTipoHabitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cTipoHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipo,nombre,descripcion")] cTipoHabitacion cTipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cTipoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cTipoHabitacion);
        }

        // GET: cTipoHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTipoHabitacion = await _context.tTipoHabitacion.FindAsync(id);
            if (cTipoHabitacion == null)
            {
                return NotFound();
            }
            return View(cTipoHabitacion);
        }

        // POST: cTipoHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipo,nombre,descripcion")] cTipoHabitacion cTipoHabitacion)
        {
            if (id != cTipoHabitacion.idTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cTipoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cTipoHabitacionExists(cTipoHabitacion.idTipo))
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
            return View(cTipoHabitacion);
        }

        // GET: cTipoHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTipoHabitacion = await _context.tTipoHabitacion
                .FirstOrDefaultAsync(m => m.idTipo == id);
            if (cTipoHabitacion == null)
            {
                return NotFound();
            }

            return View(cTipoHabitacion);
        }

        // POST: cTipoHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cTipoHabitacion = await _context.tTipoHabitacion.FindAsync(id);
            if (cTipoHabitacion != null)
            {
                _context.tTipoHabitacion.Remove(cTipoHabitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cTipoHabitacionExists(int id)
        {
            return _context.tTipoHabitacion.Any(e => e.idTipo == id);
        }
    }
}
