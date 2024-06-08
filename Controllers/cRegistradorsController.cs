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
    public class cRegistradorsController : Controller
    {
        private readonly HotelYCAContext _context;

        public cRegistradorsController(HotelYCAContext context)
        {
            _context = context;
        }

        // GET: cRegistradors
        public async Task<IActionResult> Index()
        {
            return View(await _context.tRegistrador.ToListAsync());
        }

        // GET: cRegistradors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador
                .FirstOrDefaultAsync(m => m.idRegistrador == id);
            if (cRegistrador == null)
            {
                return NotFound();
            }

            return View(cRegistrador);
        }

        // GET: cRegistradors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cRegistradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRegistrador,nombre,direccion,documento,telefono,estado,observacion")] cRegistrador cRegistrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRegistrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRegistrador);
        }

        // GET: cRegistradors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador.FindAsync(id);
            if (cRegistrador == null)
            {
                return NotFound();
            }
            return View(cRegistrador);
        }

        // POST: cRegistradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRegistrador,nombre,direccion,documento,telefono,estado,observacion")] cRegistrador cRegistrador)
        {
            if (id != cRegistrador.idRegistrador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRegistrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cRegistradorExists(cRegistrador.idRegistrador))
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
            return View(cRegistrador);
        }

        // GET: cRegistradors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador
                .FirstOrDefaultAsync(m => m.idRegistrador == id);
            if (cRegistrador == null)
            {
                return NotFound();
            }

            return View(cRegistrador);
        }

        // POST: cRegistradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cRegistrador = await _context.tRegistrador.FindAsync(id);
            if (cRegistrador != null)
            {
                _context.tRegistrador.Remove(cRegistrador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cRegistradorExists(int id)
        {
            return _context.tRegistrador.Any(e => e.idRegistrador == id);
        }
    }
}
