using AutoMapper;
using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Models;
using CSHARPAPI_VinylBook.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSHARPAPI_VinylBook.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class RecordCopyController(VinylBookContext context, IMapper mapper) : VinylBookController(context, mapper)
    {


        // RUTE
        [HttpGet]
        public ActionResult<List<RecordCopyDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<RecordCopyDTORead>>(_context.Record_Copyes.Include(r=>r.User).Include(r=>r.Album)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

        }


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<RecordCopyDTORead> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            RecordCopy? e;
            try
            {
                e = _context.Record_Copyes.Include(r => r.User).Include(r => r.Album).FirstOrDefault(r=>r.Id == id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "RecordCopy ne postoji u bazi" });
            }

            return Ok(_mapper.Map<RecordCopyDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(RecordCopyDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }


            Album? ar;
             try
            {
                ar = _context.Albums.Find(dto.AlbumIdn);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (ar == null)
            {
                return NotFound(new { poruka = "Album ne postoji u bazi" });
            }

            User? ur;
            try
            {
                ur = _context.Users.Find(dto.UserIdn);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (ur == null)
            {
                return NotFound(new { poruka = "User ne postoji u bazi" });
            }

            try

            {
                var e = _mapper.Map<RecordCopy>(dto);
                e.Album=ar;
                e.User=ur;
                _context.Record_Copyes.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<RecordCopyDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }



        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, RecordCopyDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                RecordCopy? e;
                try
                {
                    e = _context.Record_Copyes.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "RecordCopy ne postoji u bazi" });
                }
                e = _mapper.Map(dto, e);

                _context.Record_Copyes.Update(e);
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
                RecordCopy? e;
                try
                {
                    e = _context.Record_Copyes.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("RecordCopy ne postoji u bazi");
                }
                _context.Record_Copyes.Remove(e);
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
