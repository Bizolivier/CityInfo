using CityInfo.API.Models;

namespace CityInfo.API {
    public class CitiesDataStore {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get;  } = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>() 
            {   new CityDto()
                    { Id = 1,
                     Name ="New York City ",
                     Description ="the one with that big park." 
                    },
           
                new CityDto()
                    { Id = 2,
                    Name ="Antwerp ",
                     Description ="the one with the cathedral that was never really finished."
                    },
                new CityDto()
                    { Id = 3,
                    Name ="Paris",
                    Description ="the one with that big tower."
                }
            };

        }
    }
}
