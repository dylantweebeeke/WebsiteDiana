using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteMama.Data;
using WebsiteMama.Models;

namespace WebsiteMama
{
    public class BlogEntriesController : Controller
    {
        private readonly WebsiteMamaContext _context;

        public BlogEntriesController(WebsiteMamaContext context)
        {
            _context = context;
        }

        // GET: BlogEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogEntry.ToListAsync());
        }

        // GET: BlogEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Inhoud,Date")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry.FindAsync(id);
            if (blogEntry == null)
            {
                return NotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Inhoud,Date")] BlogEntry blogEntry)
        {
            if (id != blogEntry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogEntryExists(blogEntry.ID))
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
            return View(blogEntry);
        }

        // GET: BlogEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogEntry = await _context.BlogEntry.FindAsync(id);
            _context.BlogEntry.Remove(blogEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogEntryExists(int id)
        {
            return _context.BlogEntry.Any(e => e.ID == id);
        }
    }
}
