using AutoMapper;
using CSHARPAPI_VinylBook.Data;
using CSHARPAPI_VinylBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSHARPAPI_VinylBook.Controllers
{

    public abstract class VinylBookController : ControllerBase
    {

        // dependecy injection
        // 1. definira� privatno svojstvo
        protected readonly VinylBookContext _context;

        protected readonly IMapper _mapper;


        // dependecy injection
        // 2. proslijedi� instancu kroz konstruktor
        public VinylBookController(VinylBookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
