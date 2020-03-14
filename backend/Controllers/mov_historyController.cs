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
    public class mov_historyController : ControllerBase
    {
        private readonly DBContext _context;

        public mov_historyController(DBContext context)
        {
            _context = context;
        }

        // GET: api/mov_history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<mov_history>>> Getmov_histories()
        {
            return await _context.mov_histories.ToListAsync();
        }

        // GET: api/mov_history/5
        [HttpGet("{id}")]
        public async Task<ActionResult<mov_history>> Getmov_history(int id)
        {
            var mov_history = await _context.mov_histories.FindAsync(id);

            if (mov_history == null)
            {
                return NotFound();
            }

            return mov_history;
        }

        // PUT: api/mov_history/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmov_history(int id, mov_history mov_history)
        {
            if (id != mov_history.Id)
            {
                return BadRequest();
            }

            _context.Entry(mov_history).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mov_historyExists(id))
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

        // POST: api/mov_history
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<mov_history>> Postmov_history(mov_history mov_history)
        {
            _context.mov_histories.Add(mov_history);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmov_history", new { id = mov_history.Id }, mov_history);
        }

        // DELETE: api/mov_history/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<mov_history>> Deletemov_history(int id)
        {
            var mov_history = await _context.mov_histories.FindAsync(id);
            if (mov_history == null)
            {
                return NotFound();
            }

            _context.mov_histories.Remove(mov_history);
            await _context.SaveChangesAsync();

            return mov_history;
        }

        private bool mov_historyExists(int id)
        {
            return _context.mov_histories.Any(e => e.Id == id);
        }
    }
}
