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
    public class patientController : ControllerBase
    {
        private readonly DBContext _context;

        public patientController(DBContext context)
        {
            _context = context;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<patient>>> Getpatients()
        {
            return await _context.patients.ToListAsync();
        }

        // GET: api/patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<patient>> Getpatient(int id)
        {
            var patient = await _context.patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/patient/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpatient(int id, patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!patientExists(id))
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

        // POST: api/patient
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<patient>> Postpatient(patient patient)
        {
            _context.patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<patient>> Deletepatient(int id)
        {
            var patient = await _context.patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool patientExists(int id)
        {
            return _context.patients.Any(e => e.Id == id);
        }
    }
}
