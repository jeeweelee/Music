using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

[HttpPost]
public async Task<IActionResult> CreateSong(Song song)
{
    _context.Songs.Add(song);
    await _context.SaveChangesAsync();

    var createdSong = await _context.Songs
        .Include(s => s.Album)
        .FirstOrDefaultAsync(s => s.Id == song.Id);

    return CreatedAtAction(nameof(GetSongs), new { id = song.Id }, createdSong);
}
[HttpGet("{id}")]
public async Task<IActionResult> GetSongById(Guid id)
{
    var song = await _context.Songs
        .FirstOrDefaultAsync(s => s.Id == id);

    if (song == null)
    {
        return NotFound();
    }

    return Ok(song);
}
    }
}