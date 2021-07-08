using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpetual_Guardian_Test.Models;

namespace Perpetual_Guardian_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesDbsController : ControllerBase
    {
        private readonly PGDBContext _context;

        public UploadFilesDbsController(PGDBContext context)
        {
            _context = context;
        }

        // GET: api/UploadFilesDbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadFilesDb>>> GetUploadFilesDb()
        {
            return await _context.UploadFilesDb.ToListAsync();
        }

        // GET: api/UploadFilesDbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadFilesDb>> GetUploadFilesDb(int id)
        {
            var uploadFilesDb = await _context.UploadFilesDb.FindAsync(id);

            if (uploadFilesDb == null)
            {
                return NotFound();
            }

            return uploadFilesDb;
        }

        // PUT: api/UploadFilesDbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadFilesDb(int id, UploadFilesDb uploadFilesDb)
        {
            if (id != uploadFilesDb.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploadFilesDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadFilesDbExists(id))
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

        // POST: api/UploadFilesDbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UploadFilesDb>> PostUploadFilesDb(UploadFilesDb uploadFilesDb)
        {
            _context.UploadFilesDb.Add(uploadFilesDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUploadFilesDb", new { id = uploadFilesDb.Id }, uploadFilesDb);
        }

        // DELETE: api/UploadFilesDbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UploadFilesDb>> DeleteUploadFilesDb(int id)
        {
            var uploadFilesDb = await _context.UploadFilesDb.FindAsync(id);
            if (uploadFilesDb == null)
            {
                return NotFound();
            }

            _context.UploadFilesDb.Remove(uploadFilesDb);
            await _context.SaveChangesAsync();

            return uploadFilesDb;
        }

        private bool UploadFilesDbExists(int id)
        {
            return _context.UploadFilesDb.Any(e => e.Id == id);
        }
    }
}
