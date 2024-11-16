using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly DataDbContext _context;

        public AlbumController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] Album album)
        {
            if (album == null)
            {
                return BadRequest("Album cannot be null.");
            }

            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlbumById), new { id = album.Id }, album);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(Guid id)
        {
            var album = await _context.Albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (album == null)
            {
                return BadRequest("Album could not be found");             
            }
            return Ok(album);
        }
    }
}