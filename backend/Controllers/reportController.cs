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
    public class reportController : ControllerBase
    {
        private readonly DBContext _context;

        public reportController(DBContext context)
        {
            _context = context;
        }

        // GET: api/report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<report>>> Getreports()
        {
            return await _context.reports.ToListAsync();
        }

        // GET: api/report/5
        [HttpGet("{id}")]
        public async Task<ActionResult<report>> Getreport(int id)
        {
            var report = await _context.reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // PUT: api/report/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreport(int id, report report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            _context.Entry(report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reportExists(id))
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

        // POST: api/report
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<report>> Postreport(report report)
        {
            _context.reports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreport", new { id = report.Id }, report);
        }

        // DELETE: api/report/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<report>> Deletereport(int id)
        {
            var report = await _context.reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.reports.Remove(report);
            await _context.SaveChangesAsync();

            return report;
        }

        private bool reportExists(int id)
        {
            return _context.reports.Any(e => e.Id == id);
        }
    }
}
