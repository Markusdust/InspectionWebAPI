using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspectionAPI;
using InspectionAPI.Data;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypsController : ControllerBase
    {
        private readonly DataContext _context;

        public InspectionTypsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/InspectionTyps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionTyp>>> GetInspectionTyps()
        {
          if (_context.InspectionTyps == null)
          {
              return NotFound();
          }
            return await _context.InspectionTyps.ToListAsync();
        }

        // GET: api/InspectionTyps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionTyp>> GetInspectionTyp(int id)
        {
          if (_context.InspectionTyps == null)
          {
              return NotFound();
          }
            var inspectionTyp = await _context.InspectionTyps.FindAsync(id);

            if (inspectionTyp == null)
            {
                return NotFound();
            }

            return inspectionTyp;
        }

        // PUT: api/InspectionTyps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionTyp(int id, InspectionTyp inspectionTyp)
        {
            if (id != inspectionTyp.id)
            {
                return BadRequest();
            }

            _context.Entry(inspectionTyp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypExists(id))
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

        // POST: api/InspectionTyps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionTyp>> PostInspectionTyp(InspectionTyp inspectionTyp)
        {
          if (_context.InspectionTyps == null)
          {
              return Problem("Entity set 'DataContext.InspectionTyps'  is null.");
          }
            _context.InspectionTyps.Add(inspectionTyp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionTyp", new { id = inspectionTyp.id }, inspectionTyp);
        }

        // DELETE: api/InspectionTyps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionTyp(int id)
        {
            if (_context.InspectionTyps == null)
            {
                return NotFound();
            }
            var inspectionTyp = await _context.InspectionTyps.FindAsync(id);
            if (inspectionTyp == null)
            {
                return NotFound();
            }

            _context.InspectionTyps.Remove(inspectionTyp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionTypExists(int id)
        {
            return (_context.InspectionTyps?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
