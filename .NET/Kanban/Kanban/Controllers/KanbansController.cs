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
    public class KanbanBoardController : ControllerBase
    {
        private readonly KanbanContext _context;
        private readonly IDataRepository<KanbanBoard>_repo;

        public KanbanBoardController(KanbanContext context, IDataRepository<KanbanBoard> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/KanbanBoard
        [HttpGet]
        public IEnumerable<KanbanBoard> GetKanbanBoard()
        {
            return _context.Kanban.OrderByDescending(p => p.KanbanId);
        }

        // GET: api/KanbanBoard/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKanbanBoard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanbanBoard = await _context.Kanban.FindAsync(id);

            if (kanbanBoard == null)
            {
                return NotFound();
            }

            return Ok(kanbanBoard);
        }

        // PUT: api/KanbanBoard/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKanbanBoard([FromRoute] int id, [FromBody] KanbanBoard kanbanBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kanbanBoard.KanbanId)
            {
                return BadRequest();
            }

            _context.Entry(kanbanBoard).State = EntityState.Modified;

            try
            {
                _repo.Update(kanbanBoard);
                var save = await _repo.SaveAsync(kanbanBoard);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanBoardExists(id))
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

        // POST: api/KanbanBoard
        [HttpPost]
        public async Task<IActionResult> PostKanbanBoard([FromBody] KanbanBoard kanbanBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(kanbanBoard);
            var save = await _repo.SaveAsync(kanbanBoard);

            return CreatedAtAction("GetKanbanBoard", new { id = kanbanBoard.KanbanId }, kanbanBoard);
        }

        // DELETE: api/KanbanBoard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKanbanPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanbanBoard = await _context.Kanban.FindAsync(id);
            if (kanbanBoard == null)
            {
                return NotFound();
            }

            _repo.Delete(kanbanBoard);
            var save = await _repo.SaveAsync(kanbanBoard);

            return Ok(kanbanBoard);
        }

        private bool KanbanBoardExists(int id)
        {
            return _context.Kanban.Any(e => e.KanbanId == id);
        }
    }
}
