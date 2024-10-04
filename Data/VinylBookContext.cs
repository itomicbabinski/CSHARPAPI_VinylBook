using System.Text.RegularExpressions;
using CSHARPAPI_VinylBook.Models;
using Microsoft.EntityFrameworkCore;


namespace CSHARPAPI_VinylBook.Data
{
    public class VinylBookContext : DbContext
    {

        public VinylBookContext(DbContextOptions<VinylBookContext> options) : base(options)        {

        }

                            //ovo je ime baze
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<RecordCopy> Record_Copyes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // implementacija veze 1:n
            modelBuilder.Entity<RecordCopy>().HasOne(r => r.Album);
            modelBuilder.Entity<RecordCopy>().HasOne(r => r.User);

            // implementacija veze n:n
            modelBuilder.Entity<User>()
                .HasMany(u => u.Albums)
                .WithMany(a => a.Users)
                .UsingEntity<Dictionary<string, object>>("record_copyes",
                r => r.HasOne<Album>().WithMany().HasForeignKey("album"),
                r => r.HasOne<User>().WithMany().HasForeignKey("user"),
                r => r.ToTable("record_copyes")
                );

        }

    }

}


