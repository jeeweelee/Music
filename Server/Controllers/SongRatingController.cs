using Microsoft.AspNetCore.Mvc;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using music_manager_starter.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace music_manager_starter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongRatingController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongRatingController(DataDbContext context)
        {
            _context = context;
        }
        [HttpGet] // Get All Ratings, including songs
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _context.SongRatings
                .Include(r => r.Song)
                .ToListAsync();
            return Ok(ratings);
        }

        [HttpPost] // Creation of Rating
        public async Task<IActionResult> CreateRating([FromBody] SongRating rating)
        {
            var song = await _context.Songs.FindAsync(rating.SongId);

            if (song == null)
            {
                return NotFound($"Song with ID {rating.SongId} not found.");
            }

            rating.Id = Guid.NewGuid(); 
            _context.SongRatings.Add(rating); 
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetRatingById), new { id = rating.Id }, rating); 
        }
        
        [HttpGet("{id}")] // Get/Search by Rating ID (useless)
        public async Task<IActionResult> GetRatingById(Guid id)
        {
            var rating = await _context.SongRatings
                .Include(r => r.Song)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (rating == null)
            {
                return NotFound($"Rating with ID {id} not found.");
            }

            return Ok(rating);
        }

        [HttpGet("{songId:guid}")] // Get Rating by Song ID
        public async Task<IActionResult> GetRatingsBySongId(Guid songId)
        {
            var ratings = await _context.SongRatings
                .Where(r => r.SongId == songId)
                .Include(r => r.Song)
                .ToListAsync();

            if (ratings == null || !ratings.Any())
            {
                return NotFound($"No ratings found for the song with ID {songId}.");
            }

            return Ok(ratings);
        }
        [HttpGet("{songId:guid}/average")] // Calculates the average of Ratings
        public async Task<IActionResult> GetAverageRatingBySongId(Guid songId)
        {
            var ratings = await _context.SongRatings
                .Where(r => r.SongId == songId)
                .ToListAsync();

            if (ratings == null || !ratings.Any())
            {
                return NotFound("No ratings found for this song." );
            }

            var averageRating = ratings.Average(r => r.Rating);
    
            var roundedAverageRating = Math.Round(averageRating, 2);

            return Ok(new { averageRating = roundedAverageRating });
        }
        [HttpPost("{songId:guid}")] // Rate a song by ID , need this if you want to rate through songdetails
        public async Task<IActionResult> RateSong(Guid songId, [FromBody] RatingResponse ratingRequest)
        {

        if (ratingRequest.Rating < 1 || ratingRequest.Rating > 5)
        {
            return BadRequest("Rating must be between 1 and 5.");
        }
        var song = await _context.Songs.FindAsync(songId);

        if (song == null)
        {
            return NotFound("Song not found." );
        }

        var rating = new SongRating
        {
            SongId = songId,
            Rating = ratingRequest.Rating
        };

        _context.SongRatings.Add(rating);
        await _context.SaveChangesAsync();

        return Ok("Rating submitted successfully." );
    }



    }
    
}
