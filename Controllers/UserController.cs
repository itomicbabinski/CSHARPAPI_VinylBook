using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSHARPAPI_VinylBook.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly VinylBookContext _context;

        public UserController(VinylBookContext context)

        {
            _context = context;
        }

        // RUTE
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Users.Find(id));
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, User user)
        {
            var userFromDB = _context.Users.Find(id);

            // za sada ručno, kasnije Mapper
            userFromDB.Uname = user.Uname;
            userFromDB.Ulastname = user.Ulastname;
            userFromDB.Uemail = user.Uemail;
            userFromDB.Uphone = user.Uphone;
            userFromDB.Uaddress = user.Uaddress;

            _context.Users.Update(userFromDB);
            _context.SaveChanges();

            return Ok(new { message = "Changed successfully" });

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            var userFromDB = _context.Users.Find(id);
            _context.Users.Remove(userFromDB);
            _context.SaveChanges();
            return Ok(new { messagge = "Deleted successfully" });
        }

    }
}
