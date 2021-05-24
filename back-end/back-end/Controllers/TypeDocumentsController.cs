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
    public class TypeDocumentsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TypeDocumentsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDocument>>> GetTypeDocument()
        {
            return await _context.TypeDocument.ToListAsync();
        }

        // GET: api/TypeDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDocument>> GetTypeDocument(string id)
        {
            var typeDocument = await _context.TypeDocument.FindAsync(id);

            if (typeDocument == null)
            {
                return NotFound();
            }

            return typeDocument;
        }

        // PUT: api/TypeDocuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDocument(string id, TypeDocument typeDocument)
        {
            if (id != typeDocument.Name_Type_Document)
            {
                return BadRequest();
            }

            _context.Entry(typeDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDocumentExists(id))
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

        // POST: api/TypeDocuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeDocument>> PostTypeDocument(TypeDocument typeDocument)
        {
            _context.TypeDocument.Add(typeDocument);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeDocumentExists(typeDocument.Name_Type_Document))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeDocument", new { id = typeDocument.Name_Type_Document }, typeDocument);
        }

        // DELETE: api/TypeDocuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeDocument>> DeleteTypeDocument(string id)
        {
            var typeDocument = await _context.TypeDocument.FindAsync(id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            _context.TypeDocument.Remove(typeDocument);
            await _context.SaveChangesAsync();

            return typeDocument;
        }

        private bool TypeDocumentExists(string id)
        {
            return _context.TypeDocument.Any(e => e.Name_Type_Document == id);
        }
    }
}
