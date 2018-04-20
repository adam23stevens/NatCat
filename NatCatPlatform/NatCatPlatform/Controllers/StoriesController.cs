using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatCat.Platform.Data.Entities;
using NatCat.Platform.Data.Context;

namespace NatCat.Platform.Controllers
{
    [Produces("application/json")]
    [Route("api/Stories")]
    public class StoriesController : Controller
    {
        private readonly NatCatPlatformContext _context;

        public StoriesController(NatCatPlatformContext context)
        {
            _context = context;
        }

        // GET: api/Stories
        [HttpGet]
        public IEnumerable<Story> GetStory()
        {
            return _context.Story;
        }

        // GET: api/Stories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var story = await _context.Story.SingleOrDefaultAsync(m => m.Id == id);

            if (story == null)
            {
                return NotFound();
            }

            return Ok(story);
        }

        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStory([FromRoute] int id, [FromBody] Story story)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != story.Id)
            {
                return BadRequest();
            }

            _context.Entry(story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
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

        // POST: api/Stories
        [HttpPost]
        public async Task<IActionResult> PostStory([FromBody] Story story)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Story.Add(story);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStory", new { id = story.Id }, story);
        }

        // DELETE: api/Stories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var story = await _context.Story.SingleOrDefaultAsync(m => m.Id == id);
            if (story == null)
            {
                return NotFound();
            }

            _context.Story.Remove(story);
            await _context.SaveChangesAsync();

            return Ok(story);
        }

        private bool StoryExists(int id)
        {
            return _context.Story.Any(e => e.Id == id);
        }
    }
}