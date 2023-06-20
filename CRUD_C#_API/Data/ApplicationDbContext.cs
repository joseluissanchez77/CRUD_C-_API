using CRUD_C__API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRUD_C__API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Home> Homes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>().HasData(
                new Home() { 
                    Id = 1, 
                    Name = "Villas club", 
                    Description = "Conjunto residencial",
                    Price = 200, 
                    Occupants = 2, 
                    SquareMeters = 30, 
                    ImageUrl = "", 
                    Amenity = "", 
                    CreatedDate = DateTime.Now, 
                    UpdatedDate = DateTime.Now
                },
                new Home()
                {
                    Id = 2,
                    Name = "Villas españa",
                    Description = "Conjunto residencial",
                    Price = 300,
                    Occupants = 2,
                    SquareMeters = 50,
                    ImageUrl = "",
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
        }


    }
}
