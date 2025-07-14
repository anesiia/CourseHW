using Homework_7_Chervenko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Homework_7_Chervenko.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AccountingDbContext _context;

        public ExpenseController(AccountingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? month)
        {
            var expenses = _context.Expenses
                .Include(e => e.Category)
                .AsQueryable();

            if (month != null && month >= 1 && month <= 12)
            {
                expenses = expenses.Where(e => e.Date.Month == month);
            }

            ViewBag.Month = month;
            return View(await expenses.OrderByDescending(e => e.Date).ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(new Expense());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return NotFound();

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        public async Task<IActionResult> Details(int id)
        {
            var expense = await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var expense = await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (expense == null) return NotFound();

            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
