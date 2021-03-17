using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kanban.Data;
using Kanban.Models;

namespace Kanban.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly KanbanContext _context;
        private readonly IDataRepository<Column> _repo;

        public ColumnsController(KanbanContext context, IDataRepository<Column> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Columns
        [HttpGet]
        public IEnumerable<Column> GetColumns()
        {
            return _context.Column.OrderByDescending(p => p.ColumnId);
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColumn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var column = await _context.Column.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return Ok(column);
        }

        // PUT: api/Columns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn([FromRoute] int id, [FromBody] Column column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != column.ColumnId)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                _repo.Update(column);
                var save = await _repo.SaveAsync(column);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
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

        // POST: api/Columns
        [HttpPost]
        public async Task<IActionResult> PostColumn([FromBody] Column column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(column);
            var save = await _repo.SaveAsync(column);

            return CreatedAtAction("GetBlogPost", new { id = column.ColumnId }, column);
        }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColumn([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var column = await _context.Column.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _repo.Delete(column);
            var save = await _repo.SaveAsync(column);

            return Ok(column);
        }

        private bool ColumnExists(int id)
        {
            return _context.Column.Any(e => e.ColumnId == id);
        }
    }
}
