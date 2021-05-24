using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end;
using back_end.Models;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public MunicipalitiesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Municipalities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipality()
        {
            return await _context.Municipality.ToListAsync();
        }

        // GET: api/Municipalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipality>> GetMunicipality(string id)
        {
            var municipality = await _context.Municipality.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return municipality;
        }

        // PUT: api/Municipalities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipality(string id, Municipality municipality)
        {
            if (id != municipality.Municipalitys)
            {
                return BadRequest();
            }

            _context.Entry(municipality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalityExists(id))
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

        // POST: api/Municipalities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Municipality>> PostMunicipality(Municipality municipality)
        {
            _context.Municipality.Add(municipality);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MunicipalityExists(municipality.Municipalitys))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMunicipality", new { id = municipality.Municipalitys }, municipality);
        }

        // DELETE: api/Municipalities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Municipality>> DeleteMunicipality(string id)
        {
            var municipality = await _context.Municipality.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }

            _context.Municipality.Remove(municipality);
            await _context.SaveChangesAsync();

            return municipality;
        }

        private bool MunicipalityExists(string id)
        {
            return _context.Municipality.Any(e => e.Municipalitys == id);
        }
    }
}
