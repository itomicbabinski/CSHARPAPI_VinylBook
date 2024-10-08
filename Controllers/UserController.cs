using CSHARPAPI_VinylBook.Data;
using AutoMapper;
using CSHARPAPI_VinylBook.Models;
using Microsoft.AspNetCore.Mvc;
using CSHARPAPI_VinylBook.Models.DTO;

namespace CSHARPAPI_VinylBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(VinylBookContext context, IMapper mapper) : VinylBookController(context, mapper)
    {


        // RUTE
        [HttpGet]
        public ActionResult<List<UserDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<UserDTORead>>(_context.Users));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<UserDTORead> GetById(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            User? e;
            try
            {
                e = _context.Users.Find(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "User ne postoji u bazi" });
            }

            return Ok(_mapper.Map<UserDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(UserDTOInsertUpdate dto )
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<User>(dto);
                _context.Users.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<UserDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, UserDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                User? e;
                try
                {
                    e = _context.Users.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "User ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Users.Update(e);
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
                User? e;
                try
                {
                    e = _context.Users.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("User ne postoji u bazi");
                }
                _context.Users.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }


        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<UserDTORead>> TraziUser(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<User> query = _context.Users;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(u => u.Uname.ToLower().Contains(s) || u.Ulastname.ToLower().Contains(s));
                }
                var users = query.ToList();
                return Ok(_mapper.Map<List<UserDTORead>>(users));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }





    }
}
