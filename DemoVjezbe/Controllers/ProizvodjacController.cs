﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoVjezbe.Models;

namespace DemoVjezbe.Controllers
{
    public class ProizvodjacController : Controller
    {
        private readonly NasContext _context;

        public ProizvodjacController(NasContext context)
        {
            _context = context;
        }

        // GET: Proizvodjac
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvodjac.ToListAsync());
        }

        // GET: Proizvodjac/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac
                .FirstOrDefaultAsync(m => m.ProizvodjacId == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // GET: Proizvodjac/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvodjac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProizvodjacId,Naziv")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvodjac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvodjac);
        }

        // GET: Proizvodjac/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }
            return View(proizvodjac);
        }

        // POST: Proizvodjac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProizvodjacId,Naziv")] Proizvodjac proizvodjac)
        {
            if (id != proizvodjac.ProizvodjacId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvodjac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodjacExists(proizvodjac.ProizvodjacId))
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
            return View(proizvodjac);
        }

        // GET: Proizvodjac/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjac
                .FirstOrDefaultAsync(m => m.ProizvodjacId == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // POST: Proizvodjac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvodjac = await _context.Proizvodjac.FindAsync(id);
            _context.Proizvodjac.Remove(proizvodjac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodjacExists(int id)
        {
            return _context.Proizvodjac.Any(e => e.ProizvodjacId == id);
        }
    }
}
