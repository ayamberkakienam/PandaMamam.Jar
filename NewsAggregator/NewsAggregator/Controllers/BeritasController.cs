using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Models;

namespace NewsAggregator.Controllers
{
    public class BeritasController : Controller
    {
        private readonly NewsAggregatorContext _context;

        public BeritasController(NewsAggregatorContext context)
        {
            _context = context;    
        }

        // GET: Beritas
        public async Task<IActionResult> Index(string id)
        {
            var beritas = from m in _context.Berita
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                beritas = beritas.Where(s => s.title.Contains(id));
            }
            //return View(await _context.Berita.ToListAsync());
            return View(beritas);
        }

        // GET: Beritas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var berita = await _context.Berita
                .SingleOrDefaultAsync(m => m.ID == id);
            if (berita == null)
            {
                return NotFound();
            }

            return View(berita);
        }

        // GET: Beritas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beritas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,link,title,content")] Berita berita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(berita);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(berita);
        }

        // GET: Beritas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var berita = await _context.Berita.SingleOrDefaultAsync(m => m.ID == id);
            if (berita == null)
            {
                return NotFound();
            }
            return View(berita);
        }

        // POST: Beritas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,link,title,content")] Berita berita)
        {
            if (id != berita.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(berita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeritaExists(berita.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(berita);
        }

        // GET: Beritas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var berita = await _context.Berita
                .SingleOrDefaultAsync(m => m.ID == id);
            if (berita == null)
            {
                return NotFound();
            }

            return View(berita);
        }

        // POST: Beritas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var berita = await _context.Berita.SingleOrDefaultAsync(m => m.ID == id);
            _context.Berita.Remove(berita);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BeritaExists(int id)
        {
            return _context.Berita.Any(e => e.ID == id);
        }
    }
}
