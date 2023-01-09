﻿using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers {
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
       {
        [HttpGet]
        public  ActionResult <IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId) 
            {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id == cityId);
            if (city == null) {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);

        }

        [HttpGet("{pointofinterestId}")]
        public ActionResult<PointOfInterestDto>GetPointOfInterest(int cityId, int pointofinterestId)
            {
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
    }
}
