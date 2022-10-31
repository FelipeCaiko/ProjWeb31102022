using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjWeb31102022.Data;
using ProjWeb31102022.Models;

namespace ProjWeb31102022.Controllers
{
    public class WitchesController : Controller
    {
        private readonly ProjWeb31102022Context _context;

        public WitchesController(ProjWeb31102022Context context)
        {
            _context = context;
        }

        // GET: Witches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Witch.ToListAsync());
        }

        // GET: Witches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var witch = await _context.Witch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (witch == null)
            {
                return NotFound();
            }

            return View(witch);
        }

        // GET: Witches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Witches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Witch witch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(witch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(witch);
        }

        // GET: Witches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var witch = await _context.Witch.FindAsync(id);
            if (witch == null)
            {
                return NotFound();
            }
            return View(witch);
        }

        // POST: Witches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Witch witch)
        {
            if (id != witch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(witch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WitchExists(witch.Id))
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
            return View(witch);
        }

        // GET: Witches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var witch = await _context.Witch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (witch == null)
            {
                return NotFound();
            }

            return View(witch);
        }

        // POST: Witches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var witch = await _context.Witch.FindAsync(id);
            _context.Witch.Remove(witch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WitchExists(int id)
        {
            return _context.Witch.Any(e => e.Id == id);
        }
    }
}
