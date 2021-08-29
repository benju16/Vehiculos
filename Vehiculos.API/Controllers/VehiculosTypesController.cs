using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Controllers
{
    public class VehiculosTypesController : Controller
    {
        private readonly DataContext _context;

        public VehiculosTypesController(DataContext context)
        {
            _context = context;
        }
  
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculosTypes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( VehiculosType vehiculosType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculosType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculosType);
        }

        // GET: VehiculosTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosType = await _context.VehiculosTypes.FindAsync(id);
            if (vehiculosType == null)
            {
                return NotFound();
            }
            return View(vehiculosType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehiculosType vehiculosType)
        {
            if (id != vehiculosType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculosType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosTypeExists(vehiculosType.Id))
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
            return View(vehiculosType);
        }

        // GET: VehiculosTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosType = await _context.VehiculosTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculosType == null)
            {
                return NotFound();
            }

            _context.VehiculosTypes.Remove(vehiculosType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); ;
        }

        private bool VehiculosTypeExists(int id)
        {
            return _context.VehiculosTypes.Any(e => e.Id == id);
        }
    }
}
