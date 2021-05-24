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
    public class PersonalDatasController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PersonalDatasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonalDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalData>>> GetPersonalData()
        {
            return await _context.PersonalData.ToListAsync();
        }

        // GET: api/PersonalDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalData>> GetPersonalData(Int64 id)
        {
            var personalData = await _context.PersonalData.FindAsync(id);

            if (personalData == null)
            {
                return NotFound();
            }

            return personalData;
        }

        // PUT: api/PersonalDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalData(int id, PersonalData personalData)
        {
            if (id != personalData.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDataExists(id))
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

        // POST: api/PersonalDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonalData>> PostPersonalData(PersonalData personalData)
        {
            _context.PersonalData.Add(personalData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalData", new { id = personalData.Id }, personalData);

        }

        // DELETE: api/PersonalDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalData>> DeletePersonalData(int id)
        {
            var personalData = await _context.PersonalData.FindAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }

            _context.PersonalData.Remove(personalData);
            await _context.SaveChangesAsync();

            return personalData;
        }

        private bool PersonalDataExists(int id)
        {
            return _context.PersonalData.Any(e => e.Id == id);
        }
    }
}
