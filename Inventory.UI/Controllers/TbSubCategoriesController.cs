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
    public class TbSubCategoriesController : Controller
    {
        private readonly Inventory_ManagementContext _context;

        public TbSubCategoriesController(Inventory_ManagementContext context)
        {
            _context = context;
        }

        // GET: TbSubCategories
        public async Task<IActionResult> Index()
        {
            var inventory_ManagementContext = _context.TbSubCategories.Include(t => t.Category);
            return View(await inventory_ManagementContext.ToListAsync());
        }

        // GET: TbSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSubCategory = await _context.TbSubCategories
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (tbSubCategory == null)
            {
                return NotFound();
            }

            return View(tbSubCategory);
        }

        // GET: TbSubCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryDescription");
            return View();
        }

        // POST: TbSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,SubCategoryId,SubCategoryName,SubCategoryDescription,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,IsActive,IsDeleted")] TbSubCategory tbSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryDescription", tbSubCategory.CategoryId);
            return View(tbSubCategory);
        }

        // GET: TbSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSubCategory = await _context.TbSubCategories.FindAsync(id);
            if (tbSubCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryDescription", tbSubCategory.CategoryId);
            return View(tbSubCategory);
        }

        // POST: TbSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,SubCategoryId,SubCategoryName,SubCategoryDescription,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,IsActive,IsDeleted")] TbSubCategory tbSubCategory)
        {
            if (id != tbSubCategory.SubCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSubCategoryExists(tbSubCategory.SubCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.TbCategories, "CategoryId", "CategoryDescription", tbSubCategory.CategoryId);
            return View(tbSubCategory);
        }

        // GET: TbSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSubCategory = await _context.TbSubCategories
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (tbSubCategory == null)
            {
                return NotFound();
            }

            return View(tbSubCategory);
        }

        // POST: TbSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSubCategory = await _context.TbSubCategories.FindAsync(id);
            _context.TbSubCategories.Remove(tbSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSubCategoryExists(int id)
        {
            return _context.TbSubCategories.Any(e => e.SubCategoryId == id);
        }
    }
}
