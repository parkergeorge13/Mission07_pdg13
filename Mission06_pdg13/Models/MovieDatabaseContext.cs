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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationID = 1,
                    Category = "Action/Adventure",
                    Title = "Thor Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13"
                },
                new ApplicationResponse
                {
                    ApplicationID = 2,
                    Category = "Sci-Fi",
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new ApplicationResponse
                    {
                        ApplicationID = 3,
                        Category = "Comedy",
                        Title = "The Lego Batman Movie",
                        Year = 2017,
                        Director = "Chris McKay",
                        Rating = "PG"
                    }
            );
        }
    }
}
