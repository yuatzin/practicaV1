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
    public class cAlquilersController : Controller
    {
        private readonly HotelYCAContext _context;

        public cAlquilersController(HotelYCAContext context)
        {
            _context = context;
        }

        // GET: cAlquilers
        public async Task<IActionResult> Index()
        {
            return View(await _context.tAlquiler.ToListAsync());
        }

        // GET: cAlquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // GET: cAlquilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cAlquilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlquiler,fechaHoraEntrada,fechaHoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAlquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAlquiler);
        }

        // GET: cAlquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler == null)
            {
                return NotFound();
            }
            return View(cAlquiler);
        }

        // POST: cAlquilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlquiler,fechaHoraEntrada,fechahoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (id != cAlquiler.idAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cAlquilerExists(cAlquiler.idAlquiler))
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
            return View(cAlquiler);
        }

        // GET: cAlquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // POST: cAlquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler != null)
            {
                _context.tAlquiler.Remove(cAlquiler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cAlquilerExists(int id)
        {
            return _context.tAlquiler.Any(e => e.idAlquiler == id);
        }
    }
}
