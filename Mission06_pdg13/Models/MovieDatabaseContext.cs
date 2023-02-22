using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_pdg13.Models
{
    public class MovieDatabaseContext : DbContext
    {
        //Constructor
        public MovieDatabaseContext (DbContextOptions<MovieDatabaseContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId=1, CategoryName="Action/Adventure"},
                    new Category { CategoryId = 2, CategoryName = "Sci-Fi" },
                    new Category { CategoryId = 3, CategoryName = "Comedy" },
                    new Category { CategoryId = 4, CategoryName = "Romance" },
                    new Category { CategoryId = 5, CategoryName = "Documentary" },
                    new Category { CategoryId = 6, CategoryName = "Other" }
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationID = 1,
                    CategoryId = 1,
                    Title = "Thor Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationID = 2,
                    CategoryId = 2,
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new ApplicationResponse
                    {
                        ApplicationID = 3,
                        CategoryId = 3,
                        Title = "The Lego Batman Movie",
                        Year = 2017,
                        Director = "Chris McKay",
                        Rating = "PG"
                    }
            );
        }
    }
}
