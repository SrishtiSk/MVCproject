using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCproject.Data;
using MVCproject.Models;

namespace MVCproject.Controllers
{
    public class EmpScoresController : Controller
    {
        private readonly AppDBContext _context;

        public EmpScoresController(AppDBContext context)
        {
            _context = context;
        }

        // GET: EmpScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpScore.ToListAsync());
        }

        // GET: EmpScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empScore = await _context.EmpScore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empScore == null)
            {
                return NotFound();
            }

            return View(empScore);
        }

        // GET: EmpScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpScores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmpID,EmpName,ExamDate,ExamScore")] EmpScore empScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empScore);
        }

        // GET: EmpScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empScore = await _context.EmpScore.FindAsync(id);
            if (empScore == null)
            {
                return NotFound();
            }
            return View(empScore);
        }

        // POST: EmpScores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmpID,EmpName,ExamDate,ExamScore")] EmpScore empScore)
        {
            if (id != empScore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpScoreExists(empScore.ID))
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
            return View(empScore);
        }

        // GET: EmpScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empScore = await _context.EmpScore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (empScore == null)
            {
                return NotFound();
            }

            return View(empScore);
        }

        // POST: EmpScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empScore = await _context.EmpScore.FindAsync(id);
            _context.EmpScore.Remove(empScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpScoreExists(int id)
        {
            return _context.EmpScore.Any(e => e.ID == id);
        }
    }
}
