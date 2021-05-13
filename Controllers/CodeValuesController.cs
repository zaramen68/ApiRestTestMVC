using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiRestTestMVC.Models;
using System.Text.Json;

namespace ApiRestTestMVC.Controllers
{
    public class CodeValuesController : Controller
    {
        private readonly cvContext _context;

        public CodeValuesController(cvContext context)
        {
            _context = context;
        }

        // GET: CodeValues
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeValues.ToListAsync());
        }

        // GET: CodeValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeValue = await _context.CodeValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeValue == null)
            {
                return NotFound();
            }

            return View(codeValue);
        }

        // GET: CodeValues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Value")] CodeValue codeValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeValue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeValue);
        }

        // GET: CodeValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeValue = await _context.CodeValues.FindAsync(id);
            if (codeValue == null)
            {
                return NotFound();
            }
            return View(codeValue);
        }

        // POST: CodeValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Value")] CodeValue codeValue)
        {
            if (id != codeValue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeValue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeValueExists(codeValue.Id))
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
            return View(codeValue);
        }

        // GET: CodeValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeValue = await _context.CodeValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeValue == null)
            {
                return NotFound();
            }

            return View(codeValue);
        }

        // POST: CodeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeValue = await _context.CodeValues.FindAsync(id);
            _context.CodeValues.Remove(codeValue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeValueExists(int id)
        {
            return _context.CodeValues.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("Fromlist")]
        public async Task<ActionResult<List<CVData>>> Fromlist(List<CVData> js)
        {
            CodeValue codeValue;
            string content = Request.Scheme;


           
            //var dataList = JsonSerializer.Deserialize<List<CVData>>(js);
            /* 
             dataList.Sort(delegate (CodeValueData item1, CodeValueData item2)
             {
                 int res;
                 if (int.TryParse(item1.Data.Keys.First()) > int.TryParse(item2.Data.Keys.First()))
                 {
                     res = 1;

                 }
                 else if (int.TryParse(item1.Data.Keys.First()) < int.TryParse(item2.Data.Keys.First()))
                 {
                     res = -1;
                 }
                 else
                 {
                     res = 0;
                 }
                 return res;
             });
            */
            /*
            foreach (VCData item in js)
            {
                codeValue = new CodeValue();
                codeValue.Code = int.Parse(item.Data.Keys.First());
                codeValue.Value = item.Data.Values.First();
                _context.CodeValues.Add(codeValue);
                _context.SaveChangesAsync();
            }
            
            */

            return NoContent();
        }
    }
}
