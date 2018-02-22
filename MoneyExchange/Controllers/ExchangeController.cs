using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyExchange.Models;

namespace MoneyExchange.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly MvcExchangeContext _context;

        public ExchangeController(MvcExchangeContext context)
        {
            _context = context;
        }

        // GET: Exchange
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exchange.ToListAsync());
        }

        // GET: Exchange/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Exchange
                .SingleOrDefaultAsync(m => m.ID == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // GET: Exchange/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exchange/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,code,value")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                currency.value = 24.32324;
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        // GET: Exchange/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Exchange.SingleOrDefaultAsync(m => m.ID == id);
            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        // POST: Exchange/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,code,value")] Currency currency)
        {
            if (id != currency.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyExists(currency.ID))
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
            return View(currency);
        }

        // GET: Exchange/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Exchange
                .SingleOrDefaultAsync(m => m.ID == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(currency);
        }

        // POST: Exchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currency = await _context.Exchange.SingleOrDefaultAsync(m => m.ID == id);
            _context.Exchange.Remove(currency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyExists(int id)
        {
            return _context.Exchange.Any(e => e.ID == id);
        }
    }
}
