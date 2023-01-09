using CityInfo.API.Models;

namespace CityInfo.API {
    public class CitiesDataStore {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get;  } = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>() 
            {   new CityDto()
                {   Id = 1,
                    Name ="New York City ",
                    Description ="the one with that big park." ,
                    PointsOfInterest = new List< PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                           Id = 1,
                           Name = "Central park",
                           Description = "The most visited urban park in the United States"
                        },

                        new PointOfInterestDto()
                        {
                           Id = 2,
                           Name = "Empire State Building",
                           Description = "A 102-story skyscraper located in Midtown Manhattan"
                        }
                    } ,

                },
           
                new CityDto()
                    { 
                     Id = 2,
                     Name ="Antwerp ",
                     Description ="the one with the cathedral that was never really finished.",
                     PointsOfInterest = new List< PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                           Id = 3,
                           Name = "Central park",
                           Description = "The most visited urban park in the United States"
                        },

                        new PointOfInterestDto()
                        {
                           Id = 4,
                           Name = "Antwerp Central Station",
                           Description = "The finest example of railway architechure in Belgium"
                        }
                    } ,
                    },

                new CityDto()
                    { Id = 3,
                    Name ="Paris",
                    Description ="the one with that big tower.",
                    PointsOfInterest = new List< PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                           Id = 5,
                           Name = "Eifel Tower",
                           Description = "A wrought iron lattitude tower on the Champp de Mars, named after"
                        },

                        new PointOfInterestDto()
                        {
                           Id = 6,
                           Name = "The Louvre",
                           Description = "The world's largest museum."
                        }
                    } ,
                    }
            };

        }
    }
}
