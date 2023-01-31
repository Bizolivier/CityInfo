using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers {
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase {

        /*************** Exemple d injectin de dependance *************/

        private readonly ILogger<PointOfInterestController> _logger;
        private readonly LocalMailService _mailService;

        public PointOfInterestController(ILogger<PointOfInterestController> logger,LocalMailService mailService) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId) {
            try {


                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null) {

                    /*****exemple de log***************/

                    _logger.LogInformation($"city with id {cityId} was'nt found when accessing points of interest");
                    return NotFound();
                }
                return Ok(city.PointsOfInterest);

            } catch (Exception ex) {

                /*****exemple de log**************/

                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.",
                    ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }


        }
        /*******************************************************************/

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointofinterestId) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                return NotFound();

            }
            //find point of interest

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointofinterestId);
            if (pointOfInterest == null) {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatPointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest) {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) {
                return NotFound();
            }

            //demo puposes - to improved
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(c => c.Id);

            var finalPointOfInterest = new PointOfInterestDto() {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };
            city.PointsOfInterest.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new {
                cityId = cityId,
                pointOfInterestId = finalPointOfInterest.Id
            },
                                                            finalPointOfInterest);


        }
        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfinterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest) {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                return NotFound();
            }

            //find point of interest

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null) {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();



        }
        [HttpPatch("{pointofinterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId,
                                                           int pointOfInterestId,
                                                           JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null) {
                return NotFound();
            }
            var pointOfInterestToPatch = new PointOfInterestForUpdateDto() {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description,
            };
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch)) {
                return BadRequest(ModelState);
            }
            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
        [HttpDelete("{pointOfInterestId}")]

        public ActionResult DeletePoinOfInterest(int cityId, int pointOfInterestId) {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);

            if (pointOfInterestFromStore == null) {
                return NotFound();

            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);
            return NoContent();
        }
    }
}
