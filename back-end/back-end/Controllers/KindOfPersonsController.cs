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
    public class KindOfPersonsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public KindOfPersonsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KindOfPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KindOfPerson>>> GetKindOfPerson()
        {
            return await _context.KindOfPerson.ToListAsync();
        }

        // GET: api/KindOfPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KindOfPerson>> GetKindOfPerson(string id)
        {
            var kindOfPerson = await _context.KindOfPerson.FindAsync(id);

            if (kindOfPerson == null)
            {
                return NotFound();
            }

            return kindOfPerson;
        }

        // PUT: api/KindOfPersons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindOfPerson(string id, KindOfPerson kindOfPerson)
        {
            if (id != kindOfPerson.Name_KindOfPerson)
            {
                return BadRequest();
            }

            _context.Entry(kindOfPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindOfPersonExists(id))
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

        // POST: api/KindOfPersons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KindOfPerson>> PostKindOfPerson(KindOfPerson kindOfPerson)
        {
            _context.KindOfPerson.Add(kindOfPerson);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KindOfPersonExists(kindOfPerson.Name_KindOfPerson))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKindOfPerson", new { id = kindOfPerson.Name_KindOfPerson }, kindOfPerson);
        }

        // DELETE: api/KindOfPersons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KindOfPerson>> DeleteKindOfPerson(string id)
        {
            var kindOfPerson = await _context.KindOfPerson.FindAsync(id);
            if (kindOfPerson == null)
            {
                return NotFound();
            }

            _context.KindOfPerson.Remove(kindOfPerson);
            await _context.SaveChangesAsync();

            return kindOfPerson;
        }

        private bool KindOfPersonExists(string id)
        {
            return _context.KindOfPerson.Any(e => e.Name_KindOfPerson == id);
        }
    }
}
