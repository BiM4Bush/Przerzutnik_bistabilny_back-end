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
    public class KanbanPostsController : ControllerBase
    {
        private readonly KanbanContext _context;
        private readonly IDataRepository<KanbanPost> _repo;

        public KanbanPostsController(KanbanContext context, IDataRepository<KanbanPost> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/KanbanPosts
        [HttpGet]
        public IEnumerable<KanbanPost> GetKanbanPosts()
        {
            return _context.Kanban.OrderByDescending(p => p.KanbanId);
        }

        // GET: api/KanbanPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKanbanPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanbanPost = await _context.Kanban.FindAsync(id);

            if (kanbanPost == null)
            {
                return NotFound();
            }

            return Ok(kanbanPost);
        }

        // PUT: api/KanbanPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKanbanPost([FromRoute] int id, [FromBody] KanbanPost kanbanPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kanbanPost.KanbanId)
            {
                return BadRequest();
            }

            _context.Entry(kanbanPost).State = EntityState.Modified;

            try
            {
                _repo.Update(kanbanPost);
                var save = await _repo.SaveAsync(kanbanPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanPostExists(id))
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

        // POST: api/KanbanPosts
        [HttpPost]
        public async Task<IActionResult> PostBlogPost([FromBody] KanbanPost kanbanPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(kanbanPost);
            var save = await _repo.SaveAsync(kanbanPost);

            return CreatedAtAction("GetBlogPost", new { id = kanbanPost.KanbanId }, kanbanPost);
        }

        // DELETE: api/KanbanPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKanbanPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanbanPost = await _context.Kanban.FindAsync(id);
            if (kanbanPost == null)
            {
                return NotFound();
            }

            _repo.Delete(kanbanPost);
            var save = await _repo.SaveAsync(kanbanPost);

            return Ok(kanbanPost);
        }

        private bool KanbanPostExists(int id)
        {
            return _context.Kanban.Any(e => e.KanbanId == id);
        }
    }
}
