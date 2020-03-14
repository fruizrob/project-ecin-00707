using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class temp_categorizationController : ControllerBase
    {
        private readonly DBContext _context;

        public temp_categorizationController(DBContext context)
        {
            _context = context;
        }

        // GET: api/temp_categorization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<temp_categorization>>> Gettemp_categorizations()
        {
            return await _context.temp_categorizations.ToListAsync();
        }

        // GET: api/temp_categorization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<temp_categorization>> Gettemp_categorization(int id)
        {
            var temp_categorization = await _context.temp_categorizations.FindAsync(id);

            if (temp_categorization == null)
            {
                return NotFound();
            }

            return temp_categorization;
        }

        // PUT: api/temp_categorization/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttemp_categorization(int id, temp_categorization temp_categorization)
        {
            if (id != temp_categorization.Id)
            {
                return BadRequest();
            }

            _context.Entry(temp_categorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!temp_categorizationExists(id))
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

        // POST: api/temp_categorization
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<temp_categorization>> Posttemp_categorization(temp_categorization temp_categorization)
        {
            _context.temp_categorizations.Add(temp_categorization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettemp_categorization", new { id = temp_categorization.Id }, temp_categorization);
        }

        // DELETE: api/temp_categorization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<temp_categorization>> Deletetemp_categorization(int id)
        {
            var temp_categorization = await _context.temp_categorizations.FindAsync(id);
            if (temp_categorization == null)
            {
                return NotFound();
            }

            _context.temp_categorizations.Remove(temp_categorization);
            await _context.SaveChangesAsync();

            return temp_categorization;
        }

        private bool temp_categorizationExists(int id)
        {
            return _context.temp_categorizations.Any(e => e.Id == id);
        }
    }
}
