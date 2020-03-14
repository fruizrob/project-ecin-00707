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
    public class sectorController : ControllerBase
    {
        private readonly DBContext _context;

        public sectorController(DBContext context)
        {
            _context = context;
        }

        // GET: api/sector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sector>>> Getsectors()
        {
            return await _context.sectors.ToListAsync();
        }

        // GET: api/sector/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sector>> Getsector(int id)
        {
            var sector = await _context.sectors.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        // PUT: api/sector/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsector(int id, sector sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sectorExists(id))
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

        // POST: api/sector
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<sector>> Postsector(sector sector)
        {
            _context.sectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsector", new { id = sector.Id }, sector);
        }

        // DELETE: api/sector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<sector>> Deletesector(int id)
        {
            var sector = await _context.sectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        private bool sectorExists(int id)
        {
            return _context.sectors.Any(e => e.Id == id);
        }
    }
}
