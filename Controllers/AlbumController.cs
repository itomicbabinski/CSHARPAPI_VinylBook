using AutoMapper;
using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Models;
using CSHARPAPI_VinylBook.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CSHARPAPI_VinylBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlbumController(VinylBookContext context, IMapper mapper) : VinylBookController(context, mapper)
    {

        // RUTE
        [HttpGet]
        public ActionResult<List<AlbumDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<AlbumDTORead>>(_context.Albums));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<AlbumDTORead> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Album? e;
            try
            {
                e = _context.Albums.Find(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Album ne postoji u bazi" });
            }

            return Ok(_mapper.Map<AlbumDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(AlbumDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Album>(dto);
                _context.Albums.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<AlbumDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, AlbumDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Album? e;
                try
                {
                    e = _context.Albums.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Album ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Albums.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Album? e;
                try
                {
                    e = _context.Albums.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Album ne postoji u bazi");
                }
                _context.Albums.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

    }
}
