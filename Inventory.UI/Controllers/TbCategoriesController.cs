using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory.DataAccess;

namespace Inventory.Core.Controllers
{
    public class TbCategoriesController : Controller
    {
        private readonly Inventory_ManagementContext _context;

        public TbCategoriesController(Inventory_ManagementContext context)
        {
            _context = context;
        }

        // GET: TbCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCategories.ToListAsync());
        }

        // GET: TbCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbCategory == null)
            {
                return NotFound();
            }

            return View(tbCategory);
        }

        // GET: TbCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,CreatedBy,CreatedOn,IsActive,IsDeleted,ModifiedBy,ModifiedOn")] TbCategory tbCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCategory);
        }

        // GET: TbCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories.FindAsync(id);
            if (tbCategory == null)
            {
                return NotFound();
            }
            return View(tbCategory);
        }

        // POST: TbCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDescription,CreatedBy,CreatedOn,IsActive,IsDeleted,ModifiedBy,ModifiedOn")] TbCategory tbCategory)
        {
            if (id != tbCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCategoryExists(tbCategory.CategoryId))
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
            return View(tbCategory);
        }

        // GET: TbCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCategory = await _context.TbCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbCategory == null)
            {
                return NotFound();
            }

            return View(tbCategory);
        }

        // POST: TbCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCategory = await _context.TbCategories.FindAsync(id);
            _context.TbCategories.Remove(tbCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCategoryExists(int id)
        {
            return _context.TbCategories.Any(e => e.CategoryId == id);
        }
    }
}
