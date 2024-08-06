using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly FPTManagementDbContext _context;

        public ProfessorsController(FPTManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            return await _context.Professors.ToListAsync();
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }
        [HttpGet("name={name}")]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessorsByName(string name)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professors = await _context.Professors.Where(p => p.Name == name).ToListAsync();
            if(professors == null || professors.Count < 0)
            {
                return NotFound();
            }
            return professors;
        }
        [HttpGet("phone={phone}")]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessorsByPhone(string phone)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professors = await _context.Professors.Where(p => p.Phone == phone).ToListAsync();
            if (professors == null || professors.Count < 0)
            {
                return NotFound();
            }
            return professors;
        }
        [HttpGet("email={email}")]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessorsByEmail(string email)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professors = await _context.Professors.Where(p => p.Email == email).ToListAsync();
            if (professors == null || professors.Count < 0)
            {
                return NotFound();
            }
            return professors;
        }
        // PUT: api/Professors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
          if (_context.Professors == null)
          {
              return Problem("Entity set 'FPTManagementDbContext.Professors'  is null.");
          }
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new { id = professor.Id }, professor);
        }

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            if (_context.Professors == null)
            {
                return NotFound();
            }
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return (_context.Professors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
