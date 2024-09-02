using CSHARPAPI_VinylBook.Models;
using Microsoft.EntityFrameworkCore;


namespace CSHARPAPI_VinylBook.Data
{
    public class VinylBookContext : DbContext
    {

        public VinylBookContext(DbContextOptions<VinylBookContext> options) : base(options)        {

        }

        public DbSet<User> Users { get; set; }

    }

}


