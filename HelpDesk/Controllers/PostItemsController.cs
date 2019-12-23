using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    [Route("api/PostItems")]
    [ApiController]
    public class PostItemsController : ControllerBase
    {
        private readonly PostContext _context;

        public PostItemsController(PostContext context)
        {
            _context = context;
        }

        // GET: api/PostItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostItem>>> GetPostItems(string status = "ALL")
        {
            if (status == "ALL")
            {
                return await _context.PostItems.ToListAsync();
            }
            else
            {
                return await _context.PostItems.Where<PostItem>(PostItem => PostItem.Status == status).ToListAsync();
            }
        }

        // GET: api/PostItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostItem>> GetPostItem(int id)
        {
            var postItem = await _context.PostItems.FindAsync(id);

            if (postItem == null)
            {
                return NotFound();
            }

            return postItem;
        }

        // PUT: api/PostItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostItem(int id, PostItem postItem)
        {
            if (id != postItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItemExists(id))
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

        // POST: api/PostItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PostItem>> PostPostItem(PostItem postItem)
        {
            _context.PostItems.Add(postItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostItem", new { id = postItem.Id }, postItem);
        }

        // DELETE: api/PostItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostItem>> DeletePostItem(int id)
        {
            var postItem = await _context.PostItems.FindAsync(id);
            if (postItem == null)
            {
                return NotFound();
            }

            _context.PostItems.Remove(postItem);
            await _context.SaveChangesAsync();

            return postItem;
        }

        private bool PostItemExists(int id)
        {
            return _context.PostItems.Any(e => e.Id == id);
        }
    }
}
