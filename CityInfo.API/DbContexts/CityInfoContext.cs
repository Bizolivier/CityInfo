using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CityInfo.API.DbContexts {
    public class CityInfoContext:DbContext {
        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<PointOfInterest> PointOfInterests { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext>options): base (options) {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<City>().HasData
                (new City("New York city") {
                Id = 1,
                Description = "The one with the big apple",
                
                },
                new City("Antwerp") {
                    Id = 2,
                    Description = "The one with the cathedral that was never really finished",

                },
                new City("Paris") {
                    Id = 3,
                    Description = "The one with that bid tower.",

                }
            );

            modelBuilder.Entity<PointOfInterest>().HasData
               (new PointOfInterest("Cental park") {
                   Id = 1,
                   cityId = 1,
                   Description = "The most visited urban park in the United States",

               },
               new PointOfInterest("Empire State Building") {
                   Id = 2,
                   cityId = 1,
                   Description = "A 102-story skyscraper located in Midtown Manhattan ",
               },
               new PointOfInterest("Cathedral") {
                   Id = 3,
                   cityId = 2,
                   Description = "A gathic style cathedral, conceived by architect Jan",

               },
                new PointOfInterest("Antwerp Central Station") {
                    Id = 4,
                    cityId = 2,
                    Description = "The finest example of railway architecture in Belgium",

                },
                new PointOfInterest("Eiffel Tower") {
                    Id = 5,
                    cityId = 3,
                    Description = "A wrought iron lattice tower on the Champs de Mars , named Tour Eiffel",

                },
                new PointOfInterest("The Louvre") {
                    Id = 6,
                    cityId = 3,
                    Description = "The world largest museum.",

                }
           );
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    optionsBuilder.UseSqlite("Connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}


    }
}
