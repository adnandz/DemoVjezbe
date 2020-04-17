using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoVjezbe.Models;

namespace DemoVjezbe.Controllers
{
    public class AutomobilController : Controller
    {
        private readonly NasContext _context;

        public AutomobilController(NasContext context)
        {
            _context = context;
        }

        // GET: Automobil
        public async Task<IActionResult> Index(string upit, string nazivProizvodjaca)
        {
            var proizvodjaci = _context.Proizvodjac.Select(s=>s.Naziv).AsQueryable();
            var automobili = _context.Automobil.Include("Proizvodjac").AsQueryable();

            if(!string.IsNullOrEmpty(upit))
            {
               automobili = automobili.Where(x => x.NazivModela.Contains(upit)).Include("Proizvodjac");
            }

            if (!string.IsNullOrEmpty(nazivProizvodjaca)) 
            {
                proizvodjaci = proizvodjaci.Where(s=>s == nazivProizvodjaca);
            }


            var automobilProizvodjacVM = new AutomobilProizvodjacViewModel
            {
                Automobili = await automobili.ToListAsync(),
                Proizvodjaci = new SelectList(await proizvodjaci.Distinct().ToListAsync())
            };


            return View(automobilProizvodjacVM);
        }

        // GET: Automobil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .Include(a => a.Proizvodjac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobil/Create
        public IActionResult Create()
        {
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "ProizvodjacId", "Naziv");
            return View();
        }

        // POST: Automobil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivModela,GodinaProizvodnje,ProizvodjacId")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "ProizvodjacId", "ProizvodjacId", automobil.ProizvodjacId);
            return View(automobil);
        }

        // GET: Automobil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "ProizvodjacId", "Naziv", automobil.ProizvodjacId);
            return View(automobil);
        }

        // POST: Automobil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivModela,GodinaProizvodnje,ProizvodjacId")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.Id))
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
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjac, "ProizvodjacId", "ProizvodjacId", automobil.ProizvodjacId);
            return View(automobil);
        }

        // GET: Automobil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .Include(a => a.Proizvodjac)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Automobil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobil = await _context.Automobil.FindAsync(id);
            _context.Automobil.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobil.Any(e => e.Id == id);
        }
    }
}
