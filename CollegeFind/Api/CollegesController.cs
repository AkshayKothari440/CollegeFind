using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeFind.Core;
using CollegeFind.Data;

namespace CollegeFind.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly CollegeFindDBContext _context;

        public CollegesController(CollegeFindDBContext context)
        {
            _context = context;
        }

        // GET: api/Colleges
        [HttpGet]
        public IEnumerable<College> GetColleges()
        {
            return _context.Colleges;
        }

        // GET: api/Colleges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollege([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var college = await _context.Colleges.FindAsync(id);

            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        // PUT: api/Colleges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollege([FromRoute] int id, [FromBody] College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != college.Id)
            {
                return BadRequest();
            }

            _context.Entry(college).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
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

        // POST: api/Colleges
        [HttpPost]
        public async Task<IActionResult> PostCollege([FromBody] College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollege", new { id = college.Id }, college);
        }

        // DELETE: api/Colleges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollege([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }

            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();

            return Ok(college);
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.Id == id);
        }
    }
}