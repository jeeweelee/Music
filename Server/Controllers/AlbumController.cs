using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Album/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(Guid id)
        {
            var album = await _context.Albums
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (album == null)
            {
                return NotFound(new { Message = "Album could not be found." });
            }

            return Ok(album);
        }

        // POST: api/Album/add
        [HttpPost("add")]
        public async Task<IActionResult> AddAlbum([FromForm] string name, [FromForm] IFormFile? coverImage)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest(new { Message = "Album name is required." });
                }

                byte[]? imageBytes = null;
                if (coverImage != null)
                {
                    using var memoryStream = new MemoryStream();
                    await coverImage.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }

                var album = new Album
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    CoverImage = imageBytes
                };

                _context.Albums.Add(album);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Album added successfully.", Album = album });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error adding album.", Error = ex.Message });
            }
        }

        // PUT: api/Album/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(Guid id, [FromForm] string name, [FromForm] IFormFile? coverImage)
        {
            try
            {
                var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);

                if (album == null)
                {
                    return NotFound(new { Message = "Album not found." });
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    album.Name = name;
                }

                if (coverImage != null)
                {
                    using var memoryStream = new MemoryStream();
                    await coverImage.CopyToAsync(memoryStream);
                    album.CoverImage = memoryStream.ToArray();
                }

                _context.Albums.Update(album);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Album updated successfully.", Album = album });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error updating album.", Error = ex.Message });
            }
        }
    }
}
