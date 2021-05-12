using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestTestMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRestTestMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeValuesAPIController : ControllerBase
    {
        private readonly cvContext _context;

        public CodeValuesAPIController(cvContext context)
        {
            _context = context;
        }

        // GET: api/CodeValuesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeValue>>> GetCodeValues()
        {
            return await _context.CodeValues.ToListAsync();
        }

        // GET: api/CodeValuesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeValue>> GetCodeValue(int id)
        {
            var codeValue = await _context.CodeValues.FindAsync(id);

            if (codeValue == null)
            {
                return NotFound();
            }

            return codeValue;
        }

        // PUT: api/CodeValuesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeValue(int id, CodeValue codeValue)
        {
            if (id != codeValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CodeValuesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CodeValue>> PostCodeValue(CodeValue codeValue)
        {
            _context.CodeValues.Add(codeValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeValue", new { id = codeValue.Id }, codeValue);
        }

        [HttpPost]
        public async Task<ActionResult<CodeValue>> PostListCodeValue(string jsonString)
        {
            CodeValue codeValue;
            var dataList = JsonSerializer.Deserialize<List<CodeValueData>>(jsonString);
            dataList.Sort(delegate (CodeValueData item1, CodeValueData item2)
            {
                int res;
                if (int.Parse(item1.Data.Keys.First()) > int.Parse(item2.Data.Keys.First()))
                {
                    res = 1;

                }
                else if (int.Parse(item1.Data.Keys.First()) < int.Parse(item2.Data.Keys.First()))
                {
                    res = -1;
                }
                else
                {
                    res = 0;
                }
                return res;
            });
            foreach(CodeValueData item  in dataList)
            {
                codeValue = new CodeValue();
                codeValue.Code = int.Parse(item.Data.Keys.First());
                codeValue.Value = item.Data.Values.First();
                _context.CodeValues.Add(codeValue);
                await _context.SaveChangesAsync();
            }
           

            return NoContent();
        }

        // DELETE: api/CodeValuesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodeValue>> DeleteCodeValue(int id)
        {
            var codeValue = await _context.CodeValues.FindAsync(id);
            if (codeValue == null)
            {
                return NotFound();
            }

            _context.CodeValues.Remove(codeValue);
            await _context.SaveChangesAsync();

            return codeValue;
        }

        private bool CodeValueExists(int id)
        {
            return _context.CodeValues.Any(e => e.Id == id);
        }
    }
}
