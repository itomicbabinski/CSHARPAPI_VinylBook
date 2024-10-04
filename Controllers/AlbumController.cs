using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSHARPAPI_VinylBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly VinylBookContext _context;

        public AlbumController(VinylBookContext context)

        {
            _context = context;
        }

        // RUTE
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Albums);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)//--------------
        {
            return Ok(_context.Albums.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, album);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, Album album)
        {
            var albumFromDB = _context.Albums.Find(id);

            // za sada ručno, kasnije Mapper
            albumFromDB.Title = album.Title;
            albumFromDB.Artist = album.Artist;
            albumFromDB.Language = album.Language;
            albumFromDB.Genre = album.Genre;
            
            _context.Albums.Update(albumFromDB);
            _context.SaveChanges();

            return Ok(new { message = "Changed successfully" });

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            var albumFromDB = _context.Albums.Find(id);
            _context.Albums.Remove(albumFromDB);
            _context.SaveChanges();
            return Ok(new { messagge = "Deleted successfully" });
        }
    }
}
