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
    public class DataBisnessesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public DataBisnessesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DataBisnesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataBisness>>> GetDataBisness()
        {
            return await _context.DataBisness.ToListAsync();
        }

        // GET: api/DataBisnesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataBisness>> GetDataBisness(int id)
        {
            var dataBisness = await _context.DataBisness.FindAsync(id);

            if (dataBisness == null)
            {
                return NotFound();
            }

            return dataBisness;
        }

        // PUT: api/DataBisnesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataBisness(int id, DataBisness dataBisness)
        {
            if (id != dataBisness.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataBisness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataBisnessExists(id))
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

        // POST: api/DataBisnesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataBisness>> PostDataBisness(DataBisness dataBisness)
        {
            _context.DataBisness.Add(dataBisness);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataBisness", new { id = dataBisness.Id }, dataBisness);
        }

        // DELETE: api/DataBisnesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataBisness>> DeleteDataBisness(int id)
        {
            var dataBisness = await _context.DataBisness.FindAsync(id);
            if (dataBisness == null)
            {
                return NotFound();
            }

            _context.DataBisness.Remove(dataBisness);
            await _context.SaveChangesAsync();

            return dataBisness;
        }

        private bool DataBisnessExists(int id)
        {
            return _context.DataBisness.Any(e => e.Id == id);
        }
    }
}
