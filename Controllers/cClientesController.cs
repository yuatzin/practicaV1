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
    public class cClientesController : Controller
    {
        private readonly HotelYCAContext _context;

        public cClientesController(HotelYCAContext context)
        {
            _context = context;
        }

        // GET: cClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tCliente.ToListAsync());
        }

        // GET: cClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // GET: cClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCliente);
        }

        // GET: cClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente == null)
            {
                return NotFound();
            }
            return View(cCliente);
        }

        // POST: cClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (id != cCliente.idCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cClienteExists(cCliente.idCliente))
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
            return View(cCliente);
        }

        // GET: cClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // POST: cClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente != null)
            {
                _context.tCliente.Remove(cCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cClienteExists(int id)
        {
            return _context.tCliente.Any(e => e.idCliente == id);
        }
    }
}
