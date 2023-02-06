using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers {
    [ApiController]
    [Route("api/cities")]
    public class CitiesControllers :ControllerBase 
    {
        private readonly CitiesDataStore _citiesDataStore;

        public CitiesControllers (CitiesDataStore citiesDataStore) {
            _citiesDataStore = citiesDataStore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities() {
           return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity( int id) 
            {
            var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null) {
                return NotFound();
            }
            return Ok( cityToReturn);
        }

    }
}
