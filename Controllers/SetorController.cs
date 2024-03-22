using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apifuncio.Models;
using apiitens.Context;

namespace apifuncio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SetorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Setor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetSetores()
        {
          if (_context.Setores == null)
          {
              return NotFound();
          }
            return await _context.Setores.ToListAsync();
        }

        // GET: api/Setor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> GetSetor(int id)
        {
          if (_context.Setores == null)
          {
              return NotFound();
          }
            var setor = await _context.Setores.FindAsync(id);

            if (setor == null)
            {
                return NotFound();
            }

            return setor;
        }

        // PUT: api/Setor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetor(int id, Setor setor)
        {
            if (id != setor.SetorId)
            {
                return BadRequest();
            }

            _context.Entry(setor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorExists(id))
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

        // POST: api/Setor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Setor>> PostSetor(Setor setor)
        {
          if (_context.Setores == null)
          {
              return Problem("Entity set 'AppDbContext.Setores'  is null.");
          }
            _context.Setores.Add(setor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetor", new { id = setor.SetorId }, setor);
        }

        // DELETE: api/Setor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetor(int id)
        {
            if (_context.Setores == null)
            {
                return NotFound();
            }
            var setor = await _context.Setores.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }

            _context.Setores.Remove(setor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SetorExists(int id)
        {
            return (_context.Setores?.Any(e => e.SetorId == id)).GetValueOrDefault();
        }
    }
}
